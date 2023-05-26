namespace TaskManagement.Services.Models
{
    public class Project : Common
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lead { get; set; }
        public bool? IsUpgraded { get; set; } = false;
        public ICollection<Sprint>? Sprints { get; set; }
        public ICollection<UserProject>? UserProjects { get; set; }
    }
}
