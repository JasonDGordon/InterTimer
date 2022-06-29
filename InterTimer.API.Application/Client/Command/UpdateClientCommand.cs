using AutoMapper;
using InterTimer.API.Data.Repositories.Interfaces;
using InterTimer.API.Data.Entities;
using InterTimer.API.Domain.Request;
using MediatR;

namespace InterTimer.API.Application.Client.Command
{
    public class UpdateProjectCommand : IRequest
    {
        public ClientUpdateRequest UpdatedClient { get; private set; }

        public UpdateProjectCommand(ClientUpdateRequest clientRequest)
        {
            UpdatedClient = clientRequest;
        }
    }

    public class UpdateClientCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public UpdateClientCommandHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            if (request?.UpdatedClient == null || string.IsNullOrWhiteSpace(request.UpdatedClient.Name))
            {
                throw new ArgumentException("Invalid request");
            }

            if (_clientRepository.CountByName(request.UpdatedClient.Name) > 1)
            {
                throw new ArgumentException("Another client with that name already exists.");
            }

            Data.Entities.Client client = _mapper.Map<ClientUpdateRequest, Data.Entities.Client>(request.UpdatedClient);

            _clientRepository.Update(client);

            return Task.FromResult(new Unit());
        }
    }
}
