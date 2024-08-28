using LMS.Application.DAO;
using LMS.Application.Models.Dto;
using LMS.Application.Models.Entities;
using LMS.Application.Services.Interfaces;
using LMS.Application.Services.Util;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace LMS.Application.Services.Implementations
{
    public class SecondaryInfoRepository : ISecondaryInfoRepository
    {
        private readonly AppDbContext _dbcontext;

        public SecondaryInfoRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task addSecondaryInfo(SecondaryInfoDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var primaryInfo = await _dbcontext.PrimaryInfos
                .FirstOrDefaultAsync(p => p.Employee_Id == dto.Employee_Id);
            if (primaryInfo == null)
            {
                throw new ArgumentException("PrimaryInfo with the given Employee_Id does not exist.");
            }
                var secondaryInfo = await _dbcontext.SecondaryInfos
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
                    await _dbcontext.SecondaryInfos.AddAsync(second);
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
            await _dbcontext.SaveChangesAsync();
        }

    }
}
