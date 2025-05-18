using ExamManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace ExamManagementSystem.Controllers
{
    public class StudentFilterController
    {
        private readonly AppDbContext _context;

        public StudentFilterController()
        {
            _context = new AppDbContext();
        }

        // Get all available courses based on student data
        public List<Course> GetAvailableCourses()
        {
            var courseIds = _context.Students
                .Where(s => s.CourseId != null)
                .Select(s => s.CourseId!.Value)
                .Distinct()
                .ToList();

            return _context.Courses
                .Where(c => courseIds.Contains(c.CourseId))
                .ToList();
        }

        // Get all available sessions based on selected course
        public List<Session> GetAvailableSessions(int courseId)
        {
            var sessionIds = _context.Students
                .Where(s => s.CourseId == courseId && s.SessionId != null)
                .Select(s => s.SessionId!.Value)
                .Distinct()
                .ToList();

            return _context.Sessions
                .Where(s => sessionIds.Contains(s.SessionId))
                .ToList();
        }

        // Get all available sections based on selected course and session
        public List<Section> GetAvailableSections(int courseId, int sessionId)
        {
            var sectionIds = _context.Students
                .Where(s => s.CourseId == courseId && s.SessionId == sessionId && s.SectionId != null)
                .Select(s => s.SectionId!.Value)
                .Distinct()
                .ToList();

            return _context.Sections
                .Where(sec => sectionIds.Contains(sec.SectionId))
                .ToList();
        }

        // Add this method to your existing StudentFilterController class
        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }


        // Get students based on selected course, session, and section
        public List<Student> GetFilteredStudents(int courseId, int sessionId, int sectionId)
        {
            return _context.Students
                .Where(s =>
                    s.CourseId == courseId &&
                    s.SessionId == sessionId &&
                    s.SectionId == sectionId)
                .ToList();
        }
    }
}
