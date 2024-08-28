using System.ComponentModel.DataAnnotations;

namespace LMS.Application.Models.Dto
{
    public class PrimaryInfoDto
    {
        public string Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public DateOnly DateOfJoining { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public string BloodGroup { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string EmployeeStatus { get; set; }
    }
}
