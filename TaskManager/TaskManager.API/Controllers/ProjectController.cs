using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs.Projects;
using TaskManager.Application.Features.Projects.Requests.Commands;
using TaskManager.Application.Features.Projects.Requests.Queries;
using TaskManager.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public async Task<ActionResult<List<Project>>> Get()
        {
            var todos = await _mediator.Send(new GetProjectListRequest());

            return Ok(todos);
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(int id)
        {
            var todo = await _mediator.Send(new GetProjectDetailRequest { Id = id });

            return Ok(todo);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateProjectDto createProjectDto)
        {
            var command = new CreateProjectCommand { CreateProjectDto = createProjectDto };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateProjectDto updateProjectDto)
        {
            var command = new UpdateProjectCommand { UpdateProjectDto = updateProjectDto };
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}