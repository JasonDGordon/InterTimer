using AutoMapper;
using InterTimer.API.Data.Repositories.Interfaces;
using MediatR;

namespace InterTimer.API.Application.Client.Query
{
    public class ClientQuery : IRequest<Data.Entities.Client>
    {
        public int ClientId { get; private set; }

        public ClientQuery(int clientId)
        {
            ClientId = clientId;
        }
    }

    public class ClientQueryHandler : IRequestHandler<ClientQuery, Data.Entities.Client>
    {
        private readonly IClientRepository _clientRepository;

        public ClientQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<Data.Entities.Client> Handle(ClientQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_clientRepository.GetById(request.ClientId));
        }
    }
}
