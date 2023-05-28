using TaskManagement.Services.Models;
using MediatR;

namespace TaskManagement.Services.Commands.ProjectCommands
{
    public class CreateProjectCommand : IRequest<Project>
    {
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }

        public CreateProjectCommand(string? name, string? createdBy)
        {
            Name = name;
            CreatedBy = createdBy;
        }
    }
}
