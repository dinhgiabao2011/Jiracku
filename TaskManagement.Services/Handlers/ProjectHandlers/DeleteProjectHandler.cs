using MediatR;
using TaskManagement.Services.Commands.ProjectCommands;
using TaskManagement.Services.Models;
using TaskManagement.Services.Repositories.IRepositories;

namespace TaskManagement.Services.Handlers.ProjectHandlers
{
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        public DeleteProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<int> Handle(DeleteProjectCommand command, CancellationToken cancellationToken)
        {
            return await _projectRepository.Delete(command.Id);
        }
    }
}
