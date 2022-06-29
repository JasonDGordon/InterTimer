using AutoMapper;
using InterTimer.API.Data.Repositories.Interfaces;
using InterTimer.API.Data.Entities;
using InterTimer.API.Domain.Request;
using MediatR;

namespace InterTimer.API.Application.Client.Command
{
    public class CreateClientCommand : IRequest<int>
    {
        public ClientRequest NewClient { get; private set; }

        public CreateClientCommand(ClientRequest clientRequest)
        {
            NewClient = clientRequest;
        }
    }

    public class CreateClientCommandHandler: IRequestHandler<CreateClientCommand, int>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            if (request?.NewClient == null || string.IsNullOrWhiteSpace(request.NewClient.Name))
            {
                throw new ArgumentException("Invalid request");
            }

            if (_clientRepository.GetByName(request.NewClient.Name) != null)
            {
                throw new ArgumentException("Client with that name already exists.");
            }

            Data.Entities.Client client = _mapper.Map<ClientRequest, Data.Entities.Client>(request.NewClient);

            var id = _clientRepository.Create(client);

            return Task.FromResult(id);
        }
    }
}
