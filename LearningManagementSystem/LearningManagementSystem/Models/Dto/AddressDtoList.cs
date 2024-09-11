using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models.Dto
{
    public class AddressDtoList
    {
        [Required]
        public string Employee_Id { get; set; }
        public List<AddressDetailsDto> AddressDetailsDtos { get; set; }
    }
}
