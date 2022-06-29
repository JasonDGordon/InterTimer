using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterTimer.API.Data.Entities;
using InterTimer.API.Data.Repositories.Interfaces;

namespace InterTimer.API.Data.Repositories
{
    public class ProjectTaskRepository : CrudRepository<ProjectTask, int>, IProjectTaskRepository
    {
        public ProjectTaskRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public ProjectTask GetByName(string name)
        {
            return _dbContext.ProjectTasks.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
        }

        public int CountByName(string name)
        {
            return _dbContext.ProjectTasks.Count(x => x.Name.ToLower().Equals(name.ToLower()));
        }
    }
}
