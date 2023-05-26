using System;

namespace TaskManagement.Services.Models
{
    public class Column : Common
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public int? SprintId { get; set; }
        public Sprint? Sprint { get; set; }
        public ICollection<Note>? Notes { get; set; }
    }
}
