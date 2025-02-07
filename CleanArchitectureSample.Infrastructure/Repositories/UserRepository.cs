using CleanArchitectureSample.Application.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Infrastructure.Data;
using CleanArchitectureSample.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserAsync(string userId, string password)
        {
            if(string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("user id or password is not valid");
            }

            var userEF = await _context.Users.Where(x => x.UserId == userId && x.Password == password && x.IsActive == true).FirstOrDefaultAsync();
            if (userEF == null)
                throw new InvalidOperationException("User with provide credential does not exist.");

            return new User
            {

                Id = userEF.Id,
                UserId = userEF.UserId,
                FirstName = userEF.FirstName,
                LastName = userEF.LastName,
                Email = userEF.Email,
                Role = userEF.Role               
            };
        }
    }
}
