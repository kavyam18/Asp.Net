using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Models.Entity
{
    public class EducationDetail
    {
        [Key]
        public Guid Education_Id { get; set; }
        [Required]
        public string EducationType { get; set; }
        [Required]
        public string YearOfPassing { get; set; }
        [Required]
        public decimal Percentage { get; set; }
        [Required]
        public string UniversityName { get; set; }
        [Required]
        public string InstituteName { get; set; }
        [Required]
        public string Specialization { get; set; }

        //ManyToOne Relationship with PrimaryInfo
        public Guid PrimaryInfoId { get; set; }
        [ForeignKey("PrimaryInfoId")]
        public virtual PrimaryInfo PrimaryInfo { get; set; }
    }
}
