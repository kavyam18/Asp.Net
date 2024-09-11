using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models.Dto
{
    public class BankDtoList
    {
        [Required]
        public string Employee_Id { get; set; }
        public List<BankDetailsDto> BankDetailsDtos { get; set; }
    }
}
