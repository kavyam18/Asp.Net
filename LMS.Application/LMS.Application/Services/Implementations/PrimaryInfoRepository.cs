using LMS.Application.DAO;
using LMS.Application.Models.Dto;
using LMS.Application.Models.Entities;
using LMS.Application.Services.Interfaces;
using LMS.Application.Services.Util;
using Microsoft.EntityFrameworkCore;

namespace LMS.Application.Services.Implementations
{
    public class PrimaryInfoRepository : IPrimaryInfoRepository
    {
        private readonly AppDbContext _dbContext;

        public PrimaryInfoRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task addPrimaryInfo(PrimaryInfoDto dto)
        {
            if(dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            // Convert DTO to entity
            //This is often needed in applications to separate concerns and handle business logic or transformation.
            var primaryInfo = PrimaryInfoUtil.dtoToEntity(dto);
            // Check if Employee_Id already exists
            bool idExists = await _dbContext.PrimaryInfos
                .AnyAsync(e => e.Employee_Id == primaryInfo.Employee_Id);
            if (idExists)
            {
                throw new InvalidOperationException("Employee ID already exists.");
            }
            // Check if Email already exists
            bool emailExists = await _dbContext.PrimaryInfos
                .AnyAsync(e => e.Email == primaryInfo.Email);

            if (emailExists)
            {
                throw new InvalidOperationException("Email address already exists.");
            }
            try
            {
                await _dbContext.PrimaryInfos.AddAsync(primaryInfo);
                await Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding primary info.", ex);
            }
        }
        private async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task Update(PrimaryInfoDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
