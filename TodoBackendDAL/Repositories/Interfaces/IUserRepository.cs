using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBackendDAL.Entities;

namespace TodoBackendDAL.Repositories.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        public Task<User> GetUserByUsername(string username,string password);
        public Task<User> GetUserByEmail(string email,string password);
    }
}
