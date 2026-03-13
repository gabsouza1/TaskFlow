using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Interfaces;
using TaskFlow.Domain.Models;
using TaskFlow.Infrastructure.Context;

namespace TaskFlow.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(User user)
        {
            await _dataContext.Users.AddAsync(user);
        }

        public void Delete(User user)
        {
            _dataContext.Users.Remove(user);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return _dataContext.Users.Any(u => u.Email == email);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return _dataContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dataContext.Users.FindAsync(id);
        }

        public void Update(User user)
        {
            _dataContext.Users.Update(user);
        }
    }
}
