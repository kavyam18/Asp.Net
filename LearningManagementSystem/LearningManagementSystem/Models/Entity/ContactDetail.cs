using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Models.Entity
{
    public class ContactDetail
    {
        [Key]
        public Guid Contact_Id { get; set; }
        [Required]
        public string ContactType { get; set; }
        [Required]
        public long ContactNo { get; set; }

        //ManyToOne Relationship with PrimaryInfo
        //Foreign key to primaryInfo
        public Guid PrimaryInfoId { get; set; }
        [ForeignKey("PrimaryInfoId")]
        public virtual PrimaryInfo PrimaryInfo { get; set; }
    }
}
