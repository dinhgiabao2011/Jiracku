using KPTMockProject.Common.Filter;
using TaskManagement.Services.DTOs;
using TaskManagement.Services.Models;

namespace TaskManagement.Services.Repositories.IRepositories
{
    public interface IProjectRepository
    {
        Task<(List<ProjectDTO>, PaginationFilter, int)> GetProjectList(PaginationFilter filter);
        Task<Project> GetProjectById(int id);
        Task<bool> CheckProjectName(Project project);
        Task<Project> Create(Project project);
        Task<int> Update(Project project);
        Task<int> Delete(int id);
    }
}
