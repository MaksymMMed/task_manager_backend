using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Repositories.Interfaces;

namespace TodoBackendDAL.Repositories.Realizations
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ToDoContext Context;

        protected readonly DbSet<TEntity> Table;

        public GenericRepository(ToDoContext context)
        {
            Context = context;
            Table = Context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Get()
        {
            var item = await Table.ToListAsync();
            return item;
        }

        public virtual async Task Insert(TEntity entity)
        {
            await Table.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            Table.Update(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            var item = await Table.FindAsync(id);
            Table.Remove(item);
            await Context.SaveChangesAsync();
        }

        public abstract Task<TEntity> GetById(int id);
    }
}
