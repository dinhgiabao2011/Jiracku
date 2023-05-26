using System;

namespace TaskManagement.Services.Models
{
    public class Comment : Common
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public Note? Note { get; set; }
        public Issue? Issue { get; set; }
        public SubIssue? SubIssue { get; set; }
    }
}
