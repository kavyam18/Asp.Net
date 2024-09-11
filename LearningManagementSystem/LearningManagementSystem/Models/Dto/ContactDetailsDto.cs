using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models.Dto
{
    public class ContactDetailsDto
    {
        public Guid Contact_Id { get; set; }
        
        public string ContactType { get; set; }
   
        public long ContactNo { get; set; }
    }
}
