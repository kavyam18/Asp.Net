using System.ComponentModel.DataAnnotations;

namespace LMS.Application.Models.Dto
{
    public class EducationDetailsListDto
    {
        [Required]
        public string Employee_Id { get; set; }
        [Required]
        public List<EducationDetailsDto> EducationDetailsList { get; set; }

        
    }
}
