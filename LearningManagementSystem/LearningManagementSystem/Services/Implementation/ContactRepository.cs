using LearningManagementSystem.DAL;
using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Interface;
using LearningManagementSystem.Services.Util;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Services.Implementation
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext appDbContext;

        public ContactRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task addContactDetails(ContactDtoList dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var primaryInfo = await appDbContext.PrimaryInfos
                .Include(x => x.ContactInfos)
                .FirstOrDefaultAsync(p => p.Employee_Id == dto.Employee_Id);
            if (primaryInfo == null)
            {
                throw new Exception("Employee does not exist");
            }
            appDbContext.Contacts.RemoveRange(primaryInfo.ContactInfos);    
            try
            {
                var newContact = ContactUtil.dtoToContact(dto.ContactDetailsDtos, primaryInfo.PrimaryInfoId);
                primaryInfo.ContactInfos = newContact;
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
