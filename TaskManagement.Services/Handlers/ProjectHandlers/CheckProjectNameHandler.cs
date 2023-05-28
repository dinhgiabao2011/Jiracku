using MediatR;
using TaskManagement.Services.Commands.ProjectCommands;
using TaskManagement.Services.Models;
using TaskManagement.Services.Repositories.IRepositories;

namespace TaskManagement.Services.Handlers.ProjectHandlers
{
    public class CheckProjectNameHandler : IRequestHandler<CheckProjectNameCommand, bool>
    {
        private readonly IProjectRepository _projectRepository;
        public CheckProjectNameHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<bool> Handle(CheckProjectNameCommand command, CancellationToken cancellationToken)
        {
            var newProject = new Project()
            {
                Id = command.Id,
                Name = command.Name,
            };
            return await _projectRepository.CheckProjectName(newProject);
        }
    }
}
