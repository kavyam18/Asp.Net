using LearningManagementSystem.Models.Dto;
using LearningManagementSystem.Models.Entity;

namespace LearningManagementSystem.Services.Util
{
    public class TechnicalSkillUtil
    {
        public static List<TechnicalSkill> dtoToTechnical(List<TechnicalSkillDto> dtos, Guid PrimaryInfoId)
        {
            return dtos.Select(dto => new TechnicalSkill
            {
                SkillType = dto.SkillType,
                SkillRating = dto.SkillRating,
                YearOfExperience = dto.YearOfExperience,
                PrimaryInfos = new List<PrimaryInfo>()
            }).ToList();
        }
    }
}
