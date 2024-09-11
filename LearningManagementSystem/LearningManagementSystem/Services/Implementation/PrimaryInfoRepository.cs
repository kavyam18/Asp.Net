using LearningManagementSystem.DAL;
using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Interface;
using LearningManagementSystem.Services.Util;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Services.Implementation
{
    public class PrimaryInfoRepository : IPrimaryInfoRepository
    {
        private readonly AppDbContext _appDbContext;

        public PrimaryInfoRepository(AppDbContext appDbContext)
        {
          this._appDbContext = appDbContext;
        }
        public async Task addPrimaryInfo(PrimaryInfoDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            // Convert DTO to entity
            //This is often needed in applications to separate concerns and handle business logic or transformation.
            var primaryInfo = PrimaryInfoUtil.dtoToEntity(dto);
            // Check if Employee_Id already exists
            bool idExists = await _appDbContext.PrimaryInfos
                .AnyAsync(e => e.Employee_Id == primaryInfo.Employee_Id);
            if (idExists)
            {
                throw new InvalidOperationException("Employee ID already exists.");
            }
            // Check if Email already exists
            bool emailExists = await _appDbContext.PrimaryInfos
                .AnyAsync(e => e.Email == primaryInfo.Email);

            if (emailExists)
            {
                throw new InvalidOperationException("Email address already exists.");
            }
            try
            {
                await _appDbContext.PrimaryInfos.AddAsync(primaryInfo);
                await Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding primary info.", ex);
            }
        }
        private async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
