namespace TaskManagement.Services.Models
{
    public class Attachment : Common
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public Issue? Issue { get; set; }
        public SubIssue? SubIssue { get; set; }
    }
}
