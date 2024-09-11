using LearningManagementSystem.DAL;
using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Models.Entity;
using LearningManagementSystem.Services.Interface;
using LearningManagementSystem.Services.Util;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Services.Implementation
{
    public class EducationRepository : IEducationRepository
    {
        private readonly AppDbContext appDbContext;

        public EducationRepository(AppDbContext _appDbContext)
        {
            this.appDbContext = _appDbContext;
        }
        public async Task addEducationDetails(EducationDtoList dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var primaryInfo = await appDbContext.PrimaryInfos
                .Include(x => x.EducationDetails)
                .FirstOrDefaultAsync(p => p.Employee_Id == dto.Employee_Id);

            if (primaryInfo == null)
            {
                throw new ArgumentException("PrimaryInfo with the given EmployeeId does not exist.");
            }
            if (primaryInfo.EducationDetails.Any())
            {
                appDbContext.EducationDetails.RemoveRange(primaryInfo.EducationDetails);
                await appDbContext.SaveChangesAsync();
            }
            try
            {
                var newEducationDetails = EducationUtil.dtosToEducationEntities(dto.EducationDetailsDtos, primaryInfo.PrimaryInfoId);

                primaryInfo.EducationDetails = newEducationDetails;
                appDbContext.PrimaryInfos.Update(primaryInfo);
                await appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"Concurrency error:{ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving EducationDetails data:{ex.Message}");
                throw;
            }
        }

    }
}
