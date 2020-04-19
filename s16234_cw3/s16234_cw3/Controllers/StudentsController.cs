using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using s16234_cw3.Models;
using s16234_cw3.DAL;

namespace s16234_cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            Student student = _dbService.GetStudentById(id);

            if (student is null)
            {
                return NotFound("Nie znaleziono studenta");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            _dbService.AddStudent(student);

            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStd(int id, string firstName, string lastName, string indexNumber)
        {
            if (GetStudent(id) is null)
            {
                return NotFound("Nie ma ucznia o takim id");
            }
            else
            {
                _dbService.UpdateStudent(int id, string firstName, string lastName, string indexNumber);
                return Ok("Aktualizacja dokończona");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStd(int id)
        {
            _dbService.DeleteStudent(id);

            return Ok("Usuwanie ukończone");
        }
    }
}