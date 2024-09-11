namespace LearningManagementSystem.Models.Dto
{
    public class ExperienceDetailsDto
    {
        public Guid Experience_Id { get; set; }
        public string CompanyName { get; set; }
        public int YearOfExperience { get; set; }
        public DateTime DateOfJoing { get; set; }
        public DateTime DateOfRelieving { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
    }
}
