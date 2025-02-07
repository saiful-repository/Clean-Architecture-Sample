using CleanArchitectureSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string userId, string password);
    }
}
