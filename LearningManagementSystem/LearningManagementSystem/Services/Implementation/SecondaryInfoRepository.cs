using LearningManagementSystem.DAL;
using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Interface;
using LearningManagementSystem.Services.Util;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Services.Implementation
{
    public class SecondaryInfoRepository : ISecondaryInfoRepository
    {
        private readonly AppDbContext appDbContext;

        public SecondaryInfoRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task addSecondaryInfo(SecondaryInfoDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var primaryInfo = await appDbContext.PrimaryInfos
                .FirstOrDefaultAsync(p => p.Employee_Id == dto.Employee_Id);
            if (primaryInfo == null)
            {
                throw new ArgumentException("PrimaryInfo with the given Employee_Id does not exist.");
            }
            var secondaryInfo = await appDbContext.SecondaryInfos
                .FirstOrDefaultAsync(s => s.PrimaryInfoId == primaryInfo.PrimaryInfoId);
            try
            {
                if (secondaryInfo != null)
                {
                    secondaryInfo.PanNo = dto.PanNo;
                    secondaryInfo.AadharNo = dto.AadharNo;
                    secondaryInfo.PassportNo = dto.PassportNo;
                    secondaryInfo.FatherName = dto.FatherName;
                    secondaryInfo.MotherName = dto.MotherName;
                    secondaryInfo.SpouseName = dto.SpouseName;
                    secondaryInfo.MaritalStatus = dto.MaritalStatus;
                }
                else
                {
                    var second = SecondaryInfoUtil.dtoToSecondaryEntity(dto);
                    second.PrimaryInfo = primaryInfo;
                    await appDbContext.SecondaryInfos.AddAsync(second);
                    await Save();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding Secondary info.", ex);
            }
        }
        private async Task Save()
        {
            await appDbContext.SaveChangesAsync();
        }
    }
}
