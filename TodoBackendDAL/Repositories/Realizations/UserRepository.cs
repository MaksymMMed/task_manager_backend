using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Entities;
using TodoBackendDAL.Repositories.Interfaces;

namespace TodoBackendDAL.Repositories.Realizations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ToDoContext context) : base(context)
        {
        }

        public override async Task<User> GetById(int id)
        {
            var item = await Table.Where(x=>x.Id == id).FirstOrDefaultAsync();
            return item;
        }
        public async Task<User> GetUserByUsername(string username, string password)
        {
            var item = await Table.Where(x=>x.Login.Equals(username) && x.Password.Equals(password)).FirstOrDefaultAsync();
            return item;
        }
        public async Task<User> GetUserByEmail(string email, string password)
        {
            var item = await Table.Where(x => x.Login.Equals(email) && x.Password.Equals(password)).FirstOrDefaultAsync();
            return item;
        }
    }
}
