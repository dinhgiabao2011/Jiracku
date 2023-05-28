using MediatR;
using TaskManagement.Services.Commands.ProjectCommands;
using TaskManagement.Services.Models;
using TaskManagement.Services.Repositories.IRepositories;

namespace TaskManagement.Services.Handlers.ProjectHandlers
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, Project>
    {
        private readonly IProjectRepository _projectRepository;
        public CreateProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Project> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
        {
            var newProject = new Project()
            {
                Name = command.Name,
                CreatedBy = command.CreatedBy,
            };
            return await _projectRepository.Create(newProject);
        }
    }
}
