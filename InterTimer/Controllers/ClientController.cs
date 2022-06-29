using InterTimer.API.Application.Client.Command;
using InterTimer.API.Application.Client.Query;
using InterTimer.API.Data.Entities;
using InterTimer.API.Domain.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InterTimer.API.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] ClientRequest clientRequest)
        {
            var clientId = await _mediator.Send(new CreateClientCommand(clientRequest));
            return new CreatedAtActionResult(nameof(Get), nameof(ClientController), new { id = clientId }, clientRequest);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Client>> Get(int clientId)
        {
            return Ok(await _mediator.Send(new ClientQuery(clientId)));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int clientId, [FromBody] ClientUpdateRequest updateRequest)
        {
            if (clientId != updateRequest.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdateClientCommand(updateRequest));
            return NoContent();
        }
    }
}
