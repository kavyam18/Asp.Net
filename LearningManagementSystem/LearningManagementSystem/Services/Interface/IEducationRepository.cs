using LearningManagementSystem.Models.Dto;

namespace LearningManagementSystem.Services.Interface
{
    public interface IEducationRepository
    {
        Task addEducationDetails(EducationDtoList dto);
    }
}
