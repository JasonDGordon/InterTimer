using AutoMapper;
using InterTimer.API.Data.Repositories.Interfaces;
using InterTimer.API.Data.Entities;
using InterTimer.API.Domain.Request;
using MediatR;

namespace InterTimer.API.Application.Project.Command
{
    public class UpdateProjectCommand : IRequest
    {
        public ProjectUpdateRequest UpdatedProject { get; private set; }

        public UpdateProjectCommand(ProjectUpdateRequest projectRequest)
        {
            UpdatedProject = projectRequest;
        }
    }

    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            if (request?.UpdatedProject == null || string.IsNullOrWhiteSpace(request.UpdatedProject.Name))
            {
                throw new ArgumentException("Invalid request");
            }

            if (_projectRepository.CountByNameForClient(request.UpdatedProject.Name, request.UpdatedProject.ClientId) > 1)
            {
                throw new ArgumentException("Another project with that name already exists for this client.");
            }

            Data.Entities.Project project = _mapper.Map<ProjectUpdateRequest, Data.Entities.Project>(request.UpdatedProject);

            _projectRepository.Update(project);

            return Task.FromResult(new Unit());
        }
    }
}
