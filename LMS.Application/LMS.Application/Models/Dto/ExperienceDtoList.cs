using System.ComponentModel.DataAnnotations;

namespace LMS.Application.Models.Dto
{
    public class ExperienceDtoList
    {

        [Required]
        public string Employee_Id { get; set; }
        public List<ExperienceDetailsDto> ExperienceDetails { get; set; } = new List<ExperienceDetailsDto>();
    }
}
