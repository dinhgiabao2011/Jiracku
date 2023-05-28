namespace TaskManagement.Services.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsUpgraded { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
