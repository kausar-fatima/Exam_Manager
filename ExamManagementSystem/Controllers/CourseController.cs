using ExamManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagementSystem.Controllers
{
    public class CourseController
    {
        private readonly AppDbContext _context;

        public CourseController()
        {
            _context = new AppDbContext();
        }

        // Add a new course
        public Course AddCourse(string courseName)
        {
            var existingCourse = _context.Courses.FirstOrDefault(c => c.CourseName == courseName);
            if (existingCourse != null)
            {
                throw new System.Exception("Course already exists.");
            }

            var newCourse = new Course
            {
                CourseName = courseName
            };

            _context.Courses.Add(newCourse);
            _context.SaveChanges();

            return newCourse;
        }

        // Get all courses
        public List<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        // Get a course by ID
        public Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.CourseId == id)!;
        }

        // Update a course
        public bool UpdateCourse(int id, string newName)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course != null)
            {
                course.CourseName = newName;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Delete a course
        public void DeleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseId == id);

            if (course == null)
                throw new Exception("Course not found.");

            // Check if course is referenced in other tables
            bool isReferenced = _context.Students.Any(stu => stu.SessionId == id); // Add other relevant checks

            if (isReferenced)
                throw new Exception("Cannot delete course because it is in use.");

            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
    }
}
