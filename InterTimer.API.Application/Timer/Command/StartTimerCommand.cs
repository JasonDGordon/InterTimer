using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterTimer.API.Data.Repositories.Interfaces;
using MediatR;

namespace InterTimer.API.Application.Timer.Command
{
    public class StartTimerCommand: IRequest 
    {
        public StartTimerCommand()
        {

        }
    }

    public class StartTimerCommandHandler : IRequestHandler<StartTimerCommand>
    {
        private readonly ITimerRepository _timerRepository;

        public StartTimerCommandHandler(ITimerRepository timerRepository)
        {
            _timerRepository = timerRepository;
        }

        public Task<Unit> Handle(StartTimerCommand request, CancellationToken cancellationToken)
        {
            // TODO: When adding users, change this flag to sit on the user itself then it will be more efficient to check for active timers.
            if (_timerRepository.HasInProgressTimer(request.StartTimer.ClientId))
            {

            }
        }
    }
}
