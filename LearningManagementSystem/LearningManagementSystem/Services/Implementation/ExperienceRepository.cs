using LearningManagementSystem.DAL;
using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Interface;
using LearningManagementSystem.Services.Util;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Services.Implementation
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly AppDbContext appDbContext;

        public ExperienceRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task addExperienceDetails(ExperienceDtoList dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var primaryInfo = await appDbContext.PrimaryInfos
                .Include(x => x.ExperienceDetails)
                .FirstOrDefaultAsync(p => p.Employee_Id == dto.Employee_Id);
            if (primaryInfo == null)
            {
                throw new Exception("Employee does not exist");
            }
            appDbContext.Experiences.RemoveRange(primaryInfo.ExperienceDetails);
            try
            {
                var newExperience = ExperienceUtil.dtoToExperience(dto.ExperienceDetailsDtos, primaryInfo.PrimaryInfoId);
                primaryInfo.ExperienceDetails = newExperience;
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
