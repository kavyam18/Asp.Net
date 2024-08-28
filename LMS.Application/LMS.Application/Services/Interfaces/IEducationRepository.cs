using LMS.Application.Models.Dto;

namespace LMS.Application.Services.Interfaces
{
    public interface IEducationRepository
    {
        Task addEducationDetails(EducationDetailsListDto dto);
    }
}
