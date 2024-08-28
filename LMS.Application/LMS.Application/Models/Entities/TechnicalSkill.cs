using System.ComponentModel.DataAnnotations;

namespace LMS.Application.Models.Entities
{
    public class TechnicalSkill
    {
        [Key]
        public Guid Technical_Id { get; set; }
        [Required]
        public string SkillType { get; set; }
        [Required]
        public string SkillRating { get; set; }
        [Required]
        public int YearOfExperience { get; set; }

        //ManyToMany Relationship with PrimaryInfo
        public virtual ICollection<PrimaryInfo> PrimaryInfos { get; set; }
    }
}
