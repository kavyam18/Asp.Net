using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Application.Models.Entities
{
    public class BankDetail
    {
        [Key]
        public Guid Bank_Id { get; set; }
        [Required]
        public long AccountNo { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Required]
        public string IFSC_Code { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        public string State { get; set; }

        //OneToMany Relationship with PrimaryInfo
        //ForeignKey to PrimaryInfo
        public Guid PrimaryInfoId { get; set; }
        [ForeignKey("PrimaryInfoId")]
        public virtual PrimaryInfo PrimaryInfo { get; set; }
    }
}
