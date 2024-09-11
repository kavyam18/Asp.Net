using LearningManagementSystem.Models.Dto;

namespace LearningManagementSystem.Services.Interface
{
    public interface ITechnicalSkillRepository
    {
       
        Task addTechnicalSkill(TechnicalSkillDtoList dtoList);
    }
}
