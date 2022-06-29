using AutoMapper;
using InterTimer.API.Data.Repositories.Interfaces;
using MediatR;

namespace InterTimer.API.Application.Client.Query
{
    public class AllProjectsQuery : IRequest<IList<Data.Entities.Project>>
    {
        public AllProjectsQuery()
        {
        }
    }

    public class AllProjectsQueryHandler : IRequestHandler<AllProjectsQuery, IList<Data.Entities.Project>>
    {
        private readonly IProjectRepository _projectRepository;

        public AllProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<IList<Data.Entities.Project>> Handle(AllProjectsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_projectRepository.GetAll());
        }
    }
}
