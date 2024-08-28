using System.ComponentModel.DataAnnotations;

namespace LMS.Application.Models.Dto
{
    public class TechnicalSkillDto
    {
        public string Employee_Id { get; set; }
        public string SkillType { get; set; }
        public string SkillRating { get; set; }
        public int YearOfExperience { get; set; }
    }
}
