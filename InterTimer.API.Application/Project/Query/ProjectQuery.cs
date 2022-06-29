using AutoMapper;
using InterTimer.API.Data.Repositories.Interfaces;
using MediatR;

namespace InterTimer.API.Application.Project.Query
{
    public class ProjectQuery : IRequest<Data.Entities.Project>
    {
        public int ProjectId { get; private set; }

        public ProjectQuery(int projectId)
        {
            ProjectId = projectId;
        }
    }

    public class ProjectQueryHandler : IRequestHandler<ProjectQuery, Data.Entities.Project>
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<Data.Entities.Project> Handle(ProjectQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_projectRepository.GetById(request.ProjectId));
        }
    }
}
