using CURD.Contract.Repository.Generic;
using CURD.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace CURD.DAL.Repository.Generic
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected TestDB_1Entities _context;

        protected BaseRepository(TestDB_1Entities context)
        {
            _context = context;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteAll(List<T> current)
        {
            foreach (var entity in current)
            {
                Delete(entity);
            }
        }

       
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>().Where(predicate);
            return query;
        }

        public T Get(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T Insert(T entity)
        {
            return _context.Set<T>().Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
