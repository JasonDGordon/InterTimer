using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterTimer.API.Data.Entities;

namespace InterTimer.API.Data.Repositories.Interfaces
{
    public interface IProjectTaskRepository: ICrudRepository<ProjectTask, int>
    {
        ProjectTask GetByName(string name);
        int CountByName(string name);
    }
}
