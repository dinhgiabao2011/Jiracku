namespace TaskManagement.Services.Models
{
    public class Sprint : Common
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsCompleted { get; set; }
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
        public ICollection<Status>? Statuses { get; set; }
        public ICollection<Issue>? Issues { get; set; }
        public ICollection<Column>? Columns { get; set; }
        public ICollection<Page>? Pages { get; set; }
    }
}
