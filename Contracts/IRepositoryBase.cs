using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExampleAPI.Contracts
{
    public interface IRepositoryBase<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Get(int id);
        public Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);

        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);

        public Task SaveAsync();
    }
}
