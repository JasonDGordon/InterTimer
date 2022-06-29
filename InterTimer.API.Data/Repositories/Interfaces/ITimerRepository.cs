using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterTimer.API.Data.Entities;

namespace InterTimer.API.Data.Repositories.Interfaces
{
    public interface ITimerRepository: ICrudRepository<TimeEntry, int>
    {
    }
}
