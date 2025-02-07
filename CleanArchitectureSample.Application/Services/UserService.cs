using AutoMapper;
using CleanArchitectureSample.Application.DTOs;
using CleanArchitectureSample.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> GetUserAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserAsync(loginDto.UserId, loginDto.Password);
            return _mapper.Map<UserDto>(user);
        }
    }
}
