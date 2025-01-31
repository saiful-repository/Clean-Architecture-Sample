using CleanArchitectureSample.Application.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Infrastructure.Data;
using CleanArchitectureSample.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<Student> AddAsync(Student student)
        {
           if (student == null) throw new ArgumentNullException(nameof(student));

            var studentEF = new StudentEF
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email
            };

           await _context.Students.AddAsync(studentEF);
           await _context.SaveChangesAsync();

            return new Student
            {
                Id = studentEF.Id,
                FirstName = studentEF.FirstName,
                LastName = studentEF.LastName,
                Email = studentEF.Email
            };   
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var studentsEF = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (studentsEF == null)
                throw new InvalidOperationException($"Student with ID {id} does not exist.");

            _context.Students.Remove(studentsEF);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var studentsEF = await _context.Students.ToListAsync();
            var student = studentsEF.Select(studentsEF => new Student
            {
                Id = studentsEF.Id,
                FirstName = studentsEF.FirstName,
                LastName = studentsEF.LastName,
                Email = studentsEF.Email
            }).ToList();

            return student;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var studentsEF = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (studentsEF == null)
                throw new InvalidOperationException($"Student with ID {id} does not exist.");

            return new Student
            {
                Id = studentsEF.Id,
                FirstName = studentsEF.FirstName,
                LastName = studentsEF.LastName,
                Email = studentsEF.Email
            };
        }

        public async Task<bool> UpdateAsync(int id, Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));

            var studentsEF = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (studentsEF == null)
                throw new InvalidOperationException($"Student with ID {id} does not exist.");

            studentsEF.FirstName = student.FirstName;
            studentsEF.LastName = student.LastName;
            studentsEF.Email = student.Email;

            _context.Students.Update(studentsEF);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
