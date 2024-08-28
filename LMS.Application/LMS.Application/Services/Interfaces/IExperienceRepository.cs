using LMS.Application.Models.Dto;

namespace LMS.Application.Services.Interfaces
{
    public interface IExperienceRepository
    {
        Task addExperienceDetails(ExperienceDtoList dto);
        Task FindByEmployeeIdAsync(object employeeId);
    }
}
