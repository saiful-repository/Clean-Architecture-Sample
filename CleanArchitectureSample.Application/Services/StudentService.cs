using AutoMapper;
using CleanArchitectureSample.Application.DTOs;
using CleanArchitectureSample.Application.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<StudentDto> AddAsync(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            var newStudent = await _studentRepository.AddAsync(student);
            return _mapper.Map<StudentDto>(newStudent);

        }

        public Task<bool> DeleteAsync(int id)
        {
            return _studentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return _mapper.Map<StudentDto>(student);
        }

        public Task<bool> UpdateAsync(int id, StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            return _studentRepository.UpdateAsync(id, student);
        }
    }
}
