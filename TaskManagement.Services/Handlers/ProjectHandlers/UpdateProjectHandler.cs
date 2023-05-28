using MediatR;
using TaskManagement.Services.Commands.ProjectCommands;
using TaskManagement.Services.Models;
using TaskManagement.Services.Repositories.IRepositories;

namespace TaskManagement.Services.Handlers.ProjectHandlers
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        public UpdateProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<int> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
        {
            var updateProject = new Project()
            {
                Id = command.Id,
                Name = command.Name,
            };
            return await _projectRepository.Update(updateProject);
        }
    }
}
