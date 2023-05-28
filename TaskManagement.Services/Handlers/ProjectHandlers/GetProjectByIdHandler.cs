using MediatR;
using TaskManagement.Services.Models;
using TaskManagement.Services.Queries.ProjectQueries;
using TaskManagement.Services.Repositories.IRepositories;

namespace TaskManagement.Services.Handlers.ProjectHandlers
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, Models.Project>
    {
        private readonly IProjectRepository _projectRepository;
        public GetProjectByIdHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Models.Project> Handle(GetProjectByIdQuery query, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetProjectById(query.Id);
        }
    }
}
