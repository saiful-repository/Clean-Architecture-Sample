using AutoMapper;
using CleanArchitectureSample.Application.DTOs;
using CleanArchitectureSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Application.Mapper
{
    public class UserMapperProfile:Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
