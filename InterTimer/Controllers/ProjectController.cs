using InterTimer.API.Application.Project.Command;
using InterTimer.API.Application.Project.Query;
using InterTimer.API.Data.Entities;
using InterTimer.API.Domain.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InterTimer.API.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] ProjectRequest projectRequest)
        {
            var projectId = await _mediator.Send(new CreateProjectCommand(projectRequest));
            return new CreatedAtActionResult(nameof(Get), nameof(ProjectController), new { id = projectId }, projectRequest);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Project>> Get(int projectId)
        {
            return Ok(await _mediator.Send(new ProjectQuery(projectId)));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int projectId, [FromBody] ProjectUpdateRequest updateRequest)
        {
            if (projectId != updateRequest.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdateProjectCommand(updateRequest));
            return NoContent();
        }
    }
}
