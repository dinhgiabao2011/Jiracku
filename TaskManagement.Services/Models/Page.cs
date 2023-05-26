namespace TaskManagement.Services.Models
{
    public class Page : Common
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? ParentPageId { get; set; }
        public int? UserId { get; set; }
        public int? SprintId { get; set; }
        public Sprint? Sprint { get; set; }
    }
}
