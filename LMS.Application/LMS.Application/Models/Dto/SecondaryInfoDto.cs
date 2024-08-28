using System.ComponentModel.DataAnnotations;

namespace LMS.Application.Models.Dto
{
    public class SecondaryInfoDto
    {
        public string Employee_Id { get; set; }
        public string PanNo { get; set; }
        public long AadharNo { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public string PassportNo { get; set; }
        public string MaritalStatus { get; set; }
    }
}
