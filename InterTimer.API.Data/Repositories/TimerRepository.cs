using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterTimer.API.Data.Entities;
using InterTimer.API.Data.Repositories.Interfaces;

namespace InterTimer.API.Data.Repositories
{
    public class TimerRepository : CrudRepository<TimeEntry, int>, ITimerRepository
    {
        public TimerRepository(DataContext dbContext) : base(dbContext)
        {
        }

        //public bool HasInProgressTimer(int clientId)
        //{
        //    return _dbContext.TimeEntries.GroupBy(x => x.).Any(x => x.ClientId == clientId && x.InProgress);
        //}
    }
}
