using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoBackendDAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> GetById(int id);
        public Task Insert(TEntity entity);
        public Task Update(TEntity entity);
        public Task Delete(int id);
    }
}
