using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posts.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid guid);
        Task Create(T entity);
    }
}