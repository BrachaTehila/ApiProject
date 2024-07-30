using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDataBase2Context _dbContext;

        public UserRepository(StoreDataBase2Context dbContext)
        {
            _dbContext = dbContext;
        }
     
        public async Task<UsersTbl> getUserByEmailAndPassword(UserLoginDTO userLoginDTO)
        {
            return await _dbContext.UsersTbls.Where(e => e.Password == userLoginDTO.Password && e.Email == userLoginDTO.Email).FirstOrDefaultAsync();
        }

        public async Task<UsersTbl> addUser(UsersTbl user)
        {
           await _dbContext.UsersTbls.AddAsync(user);
           await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task updateUser(UsersTbl newUser)
        {
           _dbContext.UsersTbls.Update(newUser);
           await _dbContext.SaveChangesAsync();
        }
    }
}
