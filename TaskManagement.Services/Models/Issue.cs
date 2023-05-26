﻿using TaskManagement.Services.Models.Enum;

namespace TaskManagement.Services.Models
{
    public class Issue : Common
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IssueType? Type { get; set; }
        public IssuePriority? Priority { get; set; }
        public int? StoryPoint { get; set; }
        public int? Order { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int? StatusId { get; set; }
        public int? SprintId { get; set; }
        public Status? Status { get; set; }
        public Sprint? Sprint { get; set; }
        public ICollection<Attachment>? Attachments { get; set; }
        public ICollection<SubIssue>? SubIssues { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
