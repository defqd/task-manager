using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs.Todos;
using TaskManager.Application.Features.Todos.Requests.Commands;
using TaskManager.Application.Features.Todos.Requests.Queries;
using TaskManager.Application.Responses;
using TaskManager.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TodoController>
        [HttpGet]
        public async Task<ActionResult<List<Todo>>> Get()
        {
            var todos = await _mediator.Send(new GetTodoListRequest());

            return Ok(todos);
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(int id)
        {
            var todo = await _mediator.Send(new GetTodoDetailRequest {  Id = id });

            return Ok(todo);
        }

        // POST api/<TodoController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTodoDto createTodoDto)
        {
            var command = new CreateTodoCommand { CreateTodoDto = createTodoDto };
            var response = await _mediator.Send(command);

            if (response.Success == false)
                return NotFound(response);

            return Ok(response);
        }

        // PUT api/<TodoController>/5
        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateTodoDto updateTodoDto)
        {
            var command = new UpdateTodoCommand { UpdateTodoDto = updateTodoDto };
            var response = await _mediator.Send(command);

            if (response.Success == false)
                return NotFound(response);

            return Ok(response);
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteTodoCommand { Id = id };
            var response = await _mediator.Send(command);

            if (response.Success == false)
                return NotFound(response);

            return Ok(response);
        }
    }
}