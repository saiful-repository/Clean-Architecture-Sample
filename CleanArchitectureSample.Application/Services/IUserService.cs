using CleanArchitectureSample.Application.DTOs;
using CleanArchitectureSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Application.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(LoginDto loginDto);
    }
}
