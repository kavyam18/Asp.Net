using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Application.Models.Entities
{
    public class SecondaryInfo
    {
        [Key]
        public Guid Secondary_Id { get; set; }
        [Required]
        public string PanNo { get; set; }
        [Required]
        public long AadharNo { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required]
        public string SpouseName { get; set; }
        [Required]
        public string PassportNo { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public Guid PrimaryInfoId { get; set; }
        [ForeignKey("PrimaryInfoId")]
        //OneToOne RelationShip with PrimaryInfo
        public virtual PrimaryInfo PrimaryInfo { get; set; }

    }
}
