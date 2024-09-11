using LearningManagementSystem.DAL;
using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Interface;
using LearningManagementSystem.Services.Util;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Services.Implementation
{
    public class BankRepository : IBankRepository
    {
        private readonly AppDbContext appDbContext;

        public BankRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task addBankDetails(BankDtoList dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            //Fetch the primaryt information
            var primaryInfo = await appDbContext.PrimaryInfos
                .Include(x => x.BankInfos)
                .FirstOrDefaultAsync(p => p.Employee_Id == dto.Employee_Id);
            //handle the null primary exception
            if (primaryInfo == null)
            {
                throw new Exception("Employee does not exist");
            }
            // Clear existing bank details
            appDbContext.BankDetails.RemoveRange(primaryInfo.BankInfos);
            try
            {
                // Convert DTOs to BankDetails entities
                var newBank = BankUtil.dtoToBank(dto.BankDetailsDtos, primaryInfo.PrimaryInfoId);
                // Assign new bank details to primary info
               primaryInfo.BankInfos = newBank;
                // Update and save changes
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
