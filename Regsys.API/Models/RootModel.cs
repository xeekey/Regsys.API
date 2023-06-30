namespace Regsys.API.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInformation { get; set; }

        // Navigation properties
        public List<User> Users { get; set; }
        public List<ProjectTask> Tasks { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        // Foreign keys
        public int CompanyId { get; set; }

        // Navigation properties
        public Company Company { get; set; }
        public List<UserTask> UserTasks { get; set; }
        public List<TimeRegistration> TimeRegistrations { get; set; }
    }

    public class UserTask
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ProjectTask Task { get; set; }
    }

    public class ProjectTask
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        // Foreign keys
        public int CompanyId { get; set; }

        // Navigation properties
        public Company Company { get; set; }
        public List<UserTask> UserTasks { get; set; }
        public List<TimeRegistration> TimeRegistrations { get; set; }
    }

    public class TimeRegistration
    {
        public int TimeRegistrationId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BreakDuration { get; set; }
        public string Notes { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public int TaskId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ProjectTask Task { get; set; }
    }

}
