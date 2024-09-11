using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Models.Entity
{
    public class AddressDetail
    {
        [Key]
        public Guid Address_Id { get; set; }
        [Required]
        public string AddressType { get; set; }
        [Required]
        public string DoorNo { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Locality { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string LandMark { get; set; }
        [Required]
        public string PinCode { get; set; }
        [Required]
        public string State { get; set; }

        //ManyToOne Relationship with PrimaryInfo
        public Guid PrimaryInfoId { get; set; }
        [ForeignKey("PrimaryInfoId")]
        public virtual PrimaryInfo PrimaryInfo { get; set; }
    }
}
