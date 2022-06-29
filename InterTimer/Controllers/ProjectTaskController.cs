using InterTimer.API.Application.ProjectTask.Command;
using InterTimer.API.Application.ProjectTask.Query;
using InterTimer.API.Data.Entities;
using InterTimer.API.Domain.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InterTimer.API.Controllers
{
    public class ProjectTaskController : BaseController
    {
        private readonly IMediator _mediator;

        public ProjectTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] ProjectTaskRequest projectTaskRequest)
        {
            var projectTaskId = await _mediator.Send(new CreateProjectTaskCommand(projectTaskRequest));
            return new CreatedAtActionResult(nameof(Get), nameof(ProjectTaskController), new { id = projectTaskId }, projectTaskRequest);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProjectTask>> Get(int projectTaskId)
        {
            return Ok(await _mediator.Send(new ProjectTaskQuery(projectTaskId)));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int projectTaskId, [FromBody] ProjectTaskUpdateRequest updateRequest)
        {
            if (projectTaskId != updateRequest.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdateProjectTaskCommand(updateRequest));
            return NoContent();
        }
    }
}
