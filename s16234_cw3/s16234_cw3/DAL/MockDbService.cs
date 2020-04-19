using s16234_cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s16234_cw3.DAL
{
    public class MockDbService : IDbService
    {
        private static List<Student> _students;

        static MockDbService()
        {
            _students = new List<Student> {
                new Student { IdStudent = 1, FirstName="Jan", LastName = "Kowalski"},
                new Student { IdStudent = 2, FirstName="Anna", LastName = "Malewska"},
                new Student { IdStudent = 3, FirstName="Andrzej", LastName = "Andrzejewicz"}
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public Student GetStudentById(int id)
        {
            Student student = _students.Find(x => x.IdStudent == id);

            return student;
        }

        public void UpdateStudent(int id, string firstName, string lastName, string indexNumber)
        {
            Student student = GetStudentById(id);
            student.FirstName = student.FirstName;
            student.LastName = student.LastName;
            student.IndexNumber = student.IndexNumber;
        }

        public void DeleteStudent(int id)
        {
            _students.Remove(GetStudentById(id));
        }
    }
}
