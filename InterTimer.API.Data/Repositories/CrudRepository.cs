using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterTimer.API.Data.Repositories.Interfaces;

namespace InterTimer.API.Data.Repositories
{
    public class CrudRepository<T, U> : ICrudRepository<T, U> where T : class
    {
        protected readonly DataContext _dbContext;

        public CrudRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public U Create(T entity)
        {
            var finalEntity = _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return (U) finalEntity.Property("Id").CurrentValue;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteRange(List<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(U id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
