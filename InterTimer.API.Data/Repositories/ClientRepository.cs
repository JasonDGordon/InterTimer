using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterTimer.API.Data.Entities;
using InterTimer.API.Data.Repositories.Interfaces;

namespace InterTimer.API.Data.Repositories
{
    public class ClientRepository : CrudRepository<Client, int>, IClientRepository
    {
        public ClientRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public Client GetByName(string name)
        {
            return _dbContext.Clients.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
        }

        public int CountByName(string name)
        {
            return _dbContext.Clients.Count(x => x.Name.ToLower().Equals(name.ToLower()));
        }
    }
}
