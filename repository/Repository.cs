using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace repository
{
    public class Repository<T> where T: EntityBase
    {

        protected AppDbContext dbContext;

        public Repository(AppDbContext _dbContext)
        {
            if (_dbContext == null)
            {
                throw new Exception("dbContext cannot be null!");
            }

            dbContext = _dbContext;
        }

        
        public T GetById(int id)
        {
            return dbContext.Set<T>().Where(e => e.Id == id).FirstOrDefault();
        }

        public IQueryable<T> AsQueryable() 
        {
            return dbContext.Set<T>();
        }

        public IQueryable<T> WithDetails(params Expression<Func<T, object>>[] entityDelegate)
        {
            IQueryable<T> result = dbContext.Set<T>();

            foreach (var entity in entityDelegate)
            {

                return result.Include(entity);
            }

            return result;
        }

        public IEnumerable<T> ListAll()
        {
            return dbContext.Set<T>();
        }

        public void Save(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = GetById(id);
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }

        public void SaveAllChanges()
        {
            dbContext.SaveChanges();
        }

    }
}
