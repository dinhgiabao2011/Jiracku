using KPTMockProject.Common.Filter;
using KPTMockProject.Common.Helpers;
using KPTMockProject.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Services.Commands.ProjectCommands;
using TaskManagement.Services.DTOs;
using TaskManagement.Services.Models;
using TaskManagement.Services.Queries;
using TaskManagement.Services.Queries.ProjectQueries;

namespace TaskManagement.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public ProjectsController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        #region GET API
        [HttpGet]
        public async Task<IActionResult> GetProjectList([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var projectList = await _mediator.Send(new GetProjectListQuery(filter));
            var pagedResponse = PaginationHelper.CreatePagedReponse<ProjectDTO>(projectList.Item1, projectList.Item2, projectList.Item3, _uriService, route);
            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectDetail(int id)
        {
            var project = await _mediator.Send(new GetProjectByIdQuery(id));
            if (project == null)
            {
                return StatusCode(400, "Project Does Not Exist");
            }
            return Ok(project);
        }
        #endregion

        #region POST API
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {
            var checkProjectName = await _mediator.Send(new CheckProjectNameCommand(project.Id, project.Name));
            if (checkProjectName)
            {
                return StatusCode(400, "Project Name already Exist");
            }
            var newProject = await _mediator.Send(new CreateProjectCommand(project.Name,project.CreatedBy));
            return Ok(newProject);
        }
        #endregion

        #region PUT API
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject([FromBody] Project project, int id)
        {
            if(id != project.Id)
            {
                return BadRequest("Project Not found");
            }
            var checkProjectName = await _mediator.Send(new CheckProjectNameCommand(project.Id, project.Name));
            if (checkProjectName)
            {
                return StatusCode(400, "Project Name already Exist");
            }
            var newProject = await _mediator.Send(new UpdateProjectCommand(project.Id, project.Name));
            return Ok(newProject);
        }
        #endregion

        #region DELETE API
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var findProject = await _mediator.Send(new GetProjectByIdQuery(id));
            if(findProject == null)
            {
                return StatusCode(400, "Project Does Not Exist");
            }
            await _mediator.Send(new DeleteProjectCommand(id));
            return Ok();
        }
        #endregion
    }
}
