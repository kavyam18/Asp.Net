using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models.Dto
{
    public class TechnicalSkillDtoList
    {
        [Required]
        public string Employee_Id { get; set; }
        public List<TechnicalSkillDto> TechnicalSkillDtos { get; set; }
    }
}
