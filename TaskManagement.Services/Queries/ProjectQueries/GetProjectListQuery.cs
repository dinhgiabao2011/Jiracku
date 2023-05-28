using KPTMockProject.Common.Filter;
using MediatR;
using TaskManagement.Services.DTOs;

namespace TaskManagement.Services.Queries.ProjectQueries
{
    public class GetProjectListQuery : IRequest<(List<ProjectDTO>, PaginationFilter, int)>
    {
        public PaginationFilter? Filter { get; set; }
        public GetProjectListQuery(PaginationFilter filter)
        {
            Filter = filter;
        }
    }
}
