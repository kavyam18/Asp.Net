using LearningManagementSystem.Models.Dto;

namespace LearningManagementSystem.Services.Interface
{
    public interface IExperienceRepository
    {
        Task addExperienceDetails(ExperienceDtoList dto);
    }
}
