using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterTimer.API.Data.Entities;

namespace InterTimer.API.Data.Repositories.Interfaces
{
    public interface IProjectRepository: ICrudRepository<Project, int>
    {
        Project GetByNameForClient(string name, int clientId);
        int CountByNameForClient(string name, int clientId);
    }
}
