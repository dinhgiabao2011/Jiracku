using MediatR;

namespace TaskManagement.Services.Commands.ProjectCommands
{
    public class DeleteProjectCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteProjectCommand(int id)
        {
            Id = id;
        }
    }
}
