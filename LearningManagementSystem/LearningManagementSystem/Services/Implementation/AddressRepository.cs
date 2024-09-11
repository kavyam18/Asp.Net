using LearningManagementSystem.DAL;
using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Models.Entity;
using LearningManagementSystem.Services.Interface;
using LearningManagementSystem.Services.Util;
using Microsoft.EntityFrameworkCore;
using System;

namespace LearningManagementSystem.Services.Implementation
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext appDbContext;

        public AddressRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task addAddressDetails(AddressDtoList dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));   
            }
            var primaryInfo = await appDbContext.PrimaryInfos
                .Include(x => x.AddressInfos) 
                .FirstOrDefaultAsync(p => p.Employee_Id == dto.Employee_Id);
            if (primaryInfo == null)
            {
                throw new Exception("Employee does not exist");
            }
            appDbContext.AddressDetails.RemoveRange(primaryInfo.AddressInfos);
            try
            {
                var newAddress = AddressUtil.dtoToAddressEntities(dto.AddressDetailsDtos, primaryInfo.PrimaryInfoId);
                primaryInfo.AddressInfos = newAddress;
                appDbContext.PrimaryInfos.Update(primaryInfo);
                await appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving EducationDetails data:{ex.Message} ");
                throw;
            }
        }
    }
}



