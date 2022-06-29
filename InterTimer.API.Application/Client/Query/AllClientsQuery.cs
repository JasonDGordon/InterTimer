using AutoMapper;
using InterTimer.API.Data.Repositories.Interfaces;
using MediatR;

namespace InterTimer.API.Application.Client.Query
{
    public class AllClientsQuery : IRequest<IList<Data.Entities.Client>>
    {
        public AllClientsQuery()
        {
        }
    }

    public class AllClientsQueryHandler : IRequestHandler<AllClientsQuery, IList<Data.Entities.Client>>
    {
        private readonly IClientRepository _clientRepository;

        public AllClientsQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<IList<Data.Entities.Client>> Handle(AllClientsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_clientRepository.GetAll());
        }
    }
}
