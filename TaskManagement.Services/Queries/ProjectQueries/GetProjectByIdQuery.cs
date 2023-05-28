using MediatR;
using TaskManagement.Services.Models;

namespace TaskManagement.Services.Queries.ProjectQueries
{
    public class GetProjectByIdQuery : IRequest<Project>
    {
        public int Id { get; set; }
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }
    }
}
