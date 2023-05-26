namespace TaskManagement.Services.Models
{
    public class Status : Common
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public int? SprintId { get; set; }
        public Sprint? Sprint { get; set; }
        public ICollection<Issue>? Issues { get; set; }
        public ICollection<SubIssue>? SubIssues { get; set; }
    }
}
