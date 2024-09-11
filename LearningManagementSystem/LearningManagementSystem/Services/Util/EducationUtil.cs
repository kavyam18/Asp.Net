using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Models.Entity;

namespace LearningManagementSystem.Services.Util
{
    public class EducationUtil
    {
        //can use the dtoToEducationEntity method to convert EducationDetailsDto objects into EducationDetail entities.
        public static List<EducationDetail> dtosToEducationEntities(List<EducationDetailsDto> dtos, Guid PrimaryInfoId)
        {
            return dtos.Select(dto => new EducationDetail
            {
                EducationType = dto.EducationType,
                YearOfPassing = dto.YearOfPassing,
                Percentage = dto.Percentage,
                UniversityName = dto.UniversityName,
                InstituteName = dto.InstituteName,
                Specialization = dto.Specialization,
                PrimaryInfoId = PrimaryInfoId
            }).ToList();
        }
    }
}
