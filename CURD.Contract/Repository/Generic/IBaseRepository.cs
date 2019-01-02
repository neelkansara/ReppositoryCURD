using CURD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CURD.Contract.Repository.Generic
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        T Get(int id);

        T Get(Guid id);

        T Insert(T entity);

        void Delete(T entity);

        void DeleteAll(List<T> current);

        void Update(T entity);

        void Save();
    }
}
