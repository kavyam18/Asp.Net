using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models.Entity
{
    public class PrimaryInfo
    {
        [Key]
        public Guid PrimaryInfoId { get; set; }

        //Using data annotations and custom validation attributes to perform server-side validation.
        //Data Annotation Attribute for validating the Data from server side
        [Required(ErrorMessage = "Employee Id is Required")]
        [StringLength(6, ErrorMessage = "Employee Id cannot Exceed 6 Characters.")]
        public string Employee_Id { get; set; }

        [Required(ErrorMessage = "Employee Name is Required")]
        [StringLength(12, ErrorMessage = "Employee Name cannot Exceed 12 Characters.")]
        public string Employee_Name { get; set; }

        [Required(ErrorMessage = "Date of Joining is required")]
        [Display(Name = "Date of Joining")]
        [DataType(DataType.Date)]
        public DateOnly DateOfJoining { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email ID is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Blood Group is Required.")]
        public string BloodGroup { get; set; }

        [Required(ErrorMessage = "Designation is Required.")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Gender is Required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Nationality is Required.")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "EmployeeStatus is Required.")]
        public string EmployeeStatus { get; set; }

        //OneToOne RelationShip with SecondaryInfo
        public Guid? SecondaryInfoId { get; set; }
        public virtual SecondaryInfo SecondaryInfo { get; set; }

        //OneToMany Relationship with EducationDetails
        public virtual ICollection<EducationDetail> EducationDetails { get; set; }

        //OneToMany RelationShip with AddressDetails
        public virtual ICollection<AddressDetail> AddressInfos { get; set; }

        //OneToMany Relationship with BankDetails
        public virtual ICollection<BankDetail> BankInfos { get; set; }

        ////OneToMany Relationship with ExperienceDetails
        public virtual ICollection<ExperienceDetail> ExperienceDetails { get; set; }

        //OneToMany Relationship with ContactDetails
        public virtual ICollection<ContactDetail> ContactInfos { get; set; }

        //ManyToMany Relationship with TechnicalSkills
        public virtual ICollection<TechnicalSkill> TechnicalSkillsInfos { get; set; }
    }
}
