using KPTMockProject.Common.Filter;
using MediatR;
using TaskManagement.Services.DTOs;
using TaskManagement.Services.Models;
using TaskManagement.Services.Queries.ProjectQueries;
using TaskManagement.Services.Repositories.IRepositories;

namespace TaskManagement.Services.Handlers.ProjectHandlers
{
    public class GetProjectListHandler : IRequestHandler<GetProjectListQuery, (List<ProjectDTO>, PaginationFilter, int)>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectListHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<(List<ProjectDTO>, PaginationFilter, int)> Handle(GetProjectListQuery query, CancellationToken cancellationToken)
        {
            var validFilter = new PaginationFilter(query.Filter.PageNumber, query.Filter.PageSize, query.Filter.Search);
            return await _projectRepository.GetProjectList(validFilter);
        }
    }
}
