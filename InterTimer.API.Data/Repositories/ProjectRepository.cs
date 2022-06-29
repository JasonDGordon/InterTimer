using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterTimer.API.Data.Entities;
using InterTimer.API.Data.Repositories.Interfaces;

namespace InterTimer.API.Data.Repositories
{
    public class ProjectRepository : CrudRepository<Project, int>, IProjectRepository
    {
        public ProjectRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public Project GetByNameForClient(string name, int clientId)
        {
            return _dbContext.Projects.FirstOrDefault(x => x.ClientId == clientId && x.Name.ToLower().Equals(name.ToLower()));
        }

        public int CountByNameForClient(string name, int clientId)
        {
            return _dbContext.Projects.Count(x => x.ClientId == clientId && x.Name.ToLower().Equals(name.ToLower()));
        }
    }
}
