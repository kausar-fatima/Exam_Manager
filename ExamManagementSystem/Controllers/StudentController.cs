using System.Collections.Generic;
using System.Linq;
using ExamManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamManagementSystem.Controllers
{
    public class StudentController
    {
        private readonly AppDbContext _context;

        public StudentController()
        {
            _context = new AppDbContext();
        }

        public Student AddStudent(string? name, string? rollNumber, string? cnic, string? address, int? age, int? sectionId, int? sessionId, int? courseId)
        {
            var student = new Student
            {
                Name = name,
                RollNumber = rollNumber,
                Cnic = cnic,
                Address = address,
                Age = age,
                SectionId = sectionId,
                SessionId = sessionId,
                CourseId = courseId
            };

            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students
                           .OrderBy(s => s.StudentId)
                           .ToList();
        }

        public List<Student> GetFilteredStudents(int? courseId, int? sectionId, int? sessionId)
        {
            var query = _context.Students.AsQueryable();

            if (courseId.HasValue)
                query = query.Where(s => s.CourseId == courseId.Value);

            if (sectionId.HasValue)
                query = query.Where(s => s.SectionId == sectionId.Value);

            if (sessionId.HasValue)
                query = query.Where(s => s.SessionId == sessionId.Value);

            return query
                .Include(s => s.Course)
                .Include(s => s.Section)
                .Include(s => s.Session)
                .ToList();
        }


        public Student? GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.StudentId == id);
        }

        public void UpdateStudent(int id, string? name, string? rollNumber, string? cnic, string? address, int? age, int? sectionId, int? sessionId, int? courseId)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                student.Name = name;
                student.RollNumber = rollNumber;
                student.Cnic = cnic;
                student.Address = address;
                student.Age = age;
                student.SectionId = sectionId;
                student.SessionId = sessionId;
                student.CourseId = courseId;

                _context.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
