using MediatR;

namespace TaskManagement.Services.Commands.ProjectCommands
{
    public class CheckProjectNameCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CheckProjectNameCommand(int id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}
