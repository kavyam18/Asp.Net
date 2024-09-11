using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models.Dto
{
    public class EducationDtoList
    {
        [Required]
        public string Employee_Id { get; set; }
        [Required]
        public List<EducationDetailsDto> EducationDetailsDtos { get; set; }
    }
}
