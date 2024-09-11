using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Models.Entity
{
    public class ExperienceDetail
    {
        [Key]
        public Guid Experience_Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public int YearOfExperience { get; set; }
        [Required]
        public DateTime DateOfJoing { get; set; }
        [Required]
        public DateTime DateOfRelieving { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Location { get; set; }

        //OneToMany Relation with PrimaryInfo
        //Foreign Key to PrimaryInfo
        public Guid PrimaryInfoId { get; set; }
        [ForeignKey("PrimaryInfoId")]
        public virtual PrimaryInfo PrimaryInfo { get; set; }
    }
}
