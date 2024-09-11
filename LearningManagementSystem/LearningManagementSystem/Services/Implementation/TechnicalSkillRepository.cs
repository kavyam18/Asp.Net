using LearningManagementSystem.DAL;
using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Services.Interface;
using LearningManagementSystem.Services.Util;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Services.Implementation
{
    public class TechnicalSkillRepository : ITechnicalSkillRepository
    {
        private readonly AppDbContext appDbContext;

        public TechnicalSkillRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task addTechnicalSkill(TechnicalSkillDtoList dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));   
            }
            var primaryInfo = await appDbContext.PrimaryInfos
                .Include(x => x.TechnicalSkillsInfos)
                .FirstOrDefaultAsync(p => p.Employee_Id == dto.Employee_Id);
            if (primaryInfo == null)
            {
                throw new Exception(message: $"EmployeeId does not found.");
            }
            // Clear existing skills
            appDbContext.TechnicalSkills.RemoveRange(primaryInfo.TechnicalSkillsInfos);
            try
            {
                // Convert DTOs to TechnicalSkill entities
                var newSkills = TechnicalSkillUtil.dtoToTechnical(dto.TechnicalSkillDtos, primaryInfo.PrimaryInfoId);
                // Assign new skills to primary info
                primaryInfo.TechnicalSkillsInfos = newSkills;
                //save changes
                appDbContext.PrimaryInfos.Update(primaryInfo);
                await appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving Technical Skills data:{ex.Message}");
                throw;
            }
        }
    }
}
