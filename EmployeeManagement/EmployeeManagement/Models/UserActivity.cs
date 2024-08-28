namespace EmployeeManagement.Models
{
    public class UserActivity
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string? ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
