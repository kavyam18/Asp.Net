using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models.Dto
{
    public class ContactDtoList
    {
        [Required]
        public string Employee_Id { get; set; }
        [Required]
        public List<ContactDetailsDto> ContactDetailsDtos { get; set; }
    }
}
