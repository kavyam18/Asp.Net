namespace LearningManagementSystem.Models.Dto
{
    public class EducationDetailsDto
    {
        public Guid Education_Id { get; set; }
        /*public string Employee_Id { get; set; }*/
        public string EducationType { get; set; }
        public string YearOfPassing { get; set; }
        public decimal Percentage { get; set; }
        public string UniversityName { get; set; }
        public string InstituteName { get; set; }
        public string Specialization { get; set; }
    }
}
