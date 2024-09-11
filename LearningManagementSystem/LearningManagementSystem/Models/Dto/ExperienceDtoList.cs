using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models.Dto
{
    public class ExperienceDtoList
    {
        [Required]
        public string Employee_Id { get; set; }
        public List<ExperienceDetailsDto> ExperienceDetailsDtos { get; set; }
    }
}
