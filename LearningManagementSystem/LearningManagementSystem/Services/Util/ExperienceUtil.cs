using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Models.Entity;

namespace LearningManagementSystem.Services.Util
{
    public class ExperienceUtil
    {
        public static List<ExperienceDetail> dtoToExperience(List<ExperienceDetailsDto> dtos, Guid PrimaryInfoId)
        {
            return dtos.Select(dto => new ExperienceDetail
            {
                CompanyName = dto.CompanyName,
                YearOfExperience = dto.YearOfExperience,
                DateOfJoing = dto.DateOfJoing,
                DateOfRelieving = dto.DateOfRelieving,
                Designation = dto.Designation,  
                Location = dto.Location,
                PrimaryInfoId = PrimaryInfoId
            }).ToList();
        }
    }
}
