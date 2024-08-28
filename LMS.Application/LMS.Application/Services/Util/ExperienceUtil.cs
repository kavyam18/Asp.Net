using LMS.Application.Models.Dto;
using LMS.Application.Models.Entities;

namespace LMS.Application.Services.Util
{
    public class ExperienceUtil
    {
        public static ExperienceDetail dtoToEntity(ExperienceDetailsDto experienceDetailsDto)
        {
            return new ExperienceDetail
            {
                CompanyName = experienceDetailsDto.CompanyName,
                YearOfExperience = experienceDetailsDto.YearOfExperience,
                DateOfJoing = experienceDetailsDto.DateOfJoing,
                DateOfRelieving = experienceDetailsDto.DateOfRelieving,
                Designation = experienceDetailsDto.Designation,
                Location = experienceDetailsDto.Location
            };
        }
    }
}
