using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterTimer.API.Data.Repositories.Interfaces
{
    public interface ICrudRepository<T, U> where T : class
    {
        U Create(T entity);
        List<T> GetAll();
        T GetById(U id);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(List<T> entities);
    }
}
