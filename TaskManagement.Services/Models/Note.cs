using System;

namespace TaskManagement.Services.Models
{
    public class Note : Common
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? Order { get; set; }
        public int? UserId { get; set; }
        public int? ColumnId { get; set; }
        public Column? Column { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
