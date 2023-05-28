using AutoMapper;
using Dapper;
using KPTMockProject.Common.Filter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using TaskManagement.Services.DBContext;
using TaskManagement.Services.DTOs;
using TaskManagement.Services.Models;
using TaskManagement.Services.Repositories.IRepositories;
using TaskManagement.Services.Services;

namespace TaskManagement.Services.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IConfiguration _configuration;
        private readonly NpgsqlConnection _connection;
        private readonly ApplicationDbContext _context;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;
        public ProjectRepository(ApplicationDbContext context, ICacheService cacheService, IConfiguration configuration,IMapper mapper)
        {
            _context = context;
            _cacheService = cacheService;
            _configuration = configuration;
            _connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            _mapper = mapper;
        }

        #region Get Services
        public async Task<Project> GetProjectById(int id)
        {
            var cacheData = _cacheService.GetData<Project>("projects");
            if (cacheData != null)
            {
                return cacheData;
            }
            cacheData = await _connection.QueryFirstOrDefaultAsync<Project>("SELECT * FROM \"Projects\" WHERE \"Id\" = @Id", new { Id = id });
            if (cacheData == null)
            {
                return null;
            }
            var expireTime = DateTimeOffset.Now.AddSeconds(30);
            _cacheService.SetData<Project>($"projects{id}", cacheData, expireTime);
            return cacheData;
        }

        public async Task<(List<ProjectDTO>, PaginationFilter, int)> GetProjectList(PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter.Search);
            var cacheData = _cacheService.GetData<List<ProjectDTO>>("projects");
            if (cacheData != null && cacheData.Count() > 0)
            {
                return (cacheData, validFilter, cacheData.Count());
            }
            var countCacheData = 0;
            if (!String.IsNullOrEmpty(filter.Search))
            {
                var projectFilter = await _connection.QueryAsync<Project>("SELECT * FROM \"Projects\" WHERE \"Name\" = @Name", new { Name = filter.Search });
                cacheData = _mapper.Map<List<ProjectDTO>>(projectFilter)
                        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                        .Take(validFilter.PageSize).ToList();
                countCacheData = cacheData.Count();
                return (cacheData, validFilter, countCacheData);
            }
            var projects = await _connection.QueryAsync<Project>("SELECT * FROM \"Projects\"");
            cacheData =  _mapper.Map<List<ProjectDTO>>(projects)
                        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                        .Take(validFilter.PageSize).ToList();
            countCacheData = cacheData.Count();
            var expireTime = DateTimeOffset.Now.AddSeconds(30);
            _cacheService.SetData<List<ProjectDTO>>("projects", cacheData, expireTime);
            return (cacheData, validFilter, countCacheData);
        }
        #endregion

        #region Post Services
        public async Task<Project> Create(Project project)
        {
            var newProject = _context.Projects.Add(project);
            var expireTime = DateTimeOffset.Now.AddSeconds(30);
            _cacheService.SetData<Project>($"projects{project.Id}", newProject.Entity, expireTime);
            await _context.SaveChangesAsync();
            return newProject.Entity;
        }
        #endregion

        #region Put Services
        public async Task<int> Update(Project project)
        {
            var findProject = await GetProjectById(project.Id);
            findProject.Name = project.Name;
            _context.Projects.Update(findProject);
            return await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete Services
        public async Task<int> Delete(int id)
        {
            var findProject = await GetProjectById(id);
            _context.Projects.Remove(findProject);
            return await _context.SaveChangesAsync();
        }
        #endregion

        #region Check Services
        public async Task<bool> CheckProjectName(Project project)
        {
            var findProject = await _context.Projects.FirstOrDefaultAsync(x => x.Name == project.Name && x.Id != project.Id);
            if (findProject == null)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
