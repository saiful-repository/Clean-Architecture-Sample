using CleanArchitectureSample.Application.DTOs;
using CleanArchitectureSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Application.Services
{
    public interface IStudentService
    {
        Task<StudentDto> GetByIdAsync(int id);
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto> AddAsync(StudentDto studentDto);
        Task<bool> UpdateAsync(int id, StudentDto studentDto);
        Task<bool> DeleteAsync(int id);
    }
}
