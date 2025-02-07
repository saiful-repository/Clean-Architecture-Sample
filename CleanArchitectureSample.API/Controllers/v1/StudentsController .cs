using Asp.Versioning;
using CleanArchitectureSample.Application.DTOs;
using CleanArchitectureSample.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureSample.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/students")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {

            _studentService = studentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            try
            {
                var student = await _studentService.GetByIdAsync(id);
                return Ok(student);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await _studentService.GetAllAsync();
                if (students == null || !students.Any())
                {
                    return Ok(new List<StudentDto>());
                }

                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        {
            try
            {
                var newStudent = await _studentService.AddAsync(studentDto);
                return CreatedAtAction(nameof(GetStudent), new { id = newStudent.Id }, newStudent);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            try
            {
                var student = await _studentService.GetByIdAsync(id);

                var updateResult = await _studentService.UpdateAsync(id, studentDto);

                if (updateResult)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Failed to update student.");
                }
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await _studentService.GetByIdAsync(id);
                var deleteResult = await _studentService.DeleteAsync(id);
                if (deleteResult)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Failed to delete student.");
                }
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
