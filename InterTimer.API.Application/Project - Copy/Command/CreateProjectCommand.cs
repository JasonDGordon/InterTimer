using AutoMapper;
using InterTimer.API.Data.Repositories.Interfaces;
using InterTimer.API.Data.Entities;
using InterTimer.API.Domain.Request;
using MediatR;

namespace InterTimer.API.Application.Project.Command
{
    public class CreateProjectCommand : IRequest<int>
    {
        public ProjectRequest NewProject { get; private set; }

        public CreateProjectCommand(ProjectRequest projectRequest)
        {
            NewProject = projectRequest;
        }
    }

    public class CreateProjectCommandHandler: IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if (request?.NewProject == null || string.IsNullOrWhiteSpace(request.NewProject.Name))
            {
                throw new ArgumentException("Invalid request");
            }

            if (_projectRepository.GetByNameForClient(request.NewProject.Name, request.NewProject.ClientId) != null)
            {
                throw new ArgumentException("Project with that name already exists for this client.");
            }

            Data.Entities.Project project = _mapper.Map<ProjectRequest, Data.Entities.Project>(request.NewProject);

            var id = _projectRepository.Create(project);

            return Task.FromResult(id);
        }
    }
}
