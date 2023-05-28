using MediatR;
using TaskManagement.Services.Models;

namespace TaskManagement.Services.Commands.ProjectCommands
{
    public class UpdateProjectCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public UpdateProjectCommand(int id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}
