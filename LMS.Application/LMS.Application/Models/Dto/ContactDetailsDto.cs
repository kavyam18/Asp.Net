using System.ComponentModel.DataAnnotations;

namespace LMS.Application.Models.Dto
{
    public class ContactDetailsDto
    {
        public string Employee_Id { get; set; }
        public string ContactType { get; set; }
        public long ContactNo { get; set; }
    }
}
