using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task Create(T entity);
        public Task Update(T entity);
        public Task Delete(object id);
    }
}
