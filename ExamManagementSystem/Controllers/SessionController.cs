using System.Collections.Generic;
using System.Linq;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.Controllers
{
    public class SessionController
    {
        private readonly AppDbContext _context;

        public SessionController()
        {
            _context = new AppDbContext();
        }

        public Session AddSession(string name, DateOnly startDate, DateOnly endDate)
        {
            var existing = _context.Sessions.FirstOrDefault(s => s.SessionName == name);
            if (existing != null)
                throw new System.Exception("Session already exists.");

            var session = new Session
            {
                SessionName = name,
                StartDate = startDate,
                EndDate = endDate
            };
            _context.Sessions.Add(session);
            _context.SaveChanges();

            return session;
        }

        public List<Session> GetAllSessions()
        {
            return _context.Sessions.ToList();
        }

        public Session GetSessionById(int id)
        {
            return _context.Sessions.FirstOrDefault(s => s.SessionId == id)!;
        }

        public void UpdateSession(int id, string name, DateOnly startDate, DateOnly endDate)
        {
            var session = _context.Sessions.FirstOrDefault(s => s.SessionId == id);
            if (session != null)
            {
                session.SessionName = name;
                session.StartDate = startDate;
                session.EndDate = endDate;
                _context.SaveChanges();
            }
        }

        public void DeleteSession(int id)
        {
            var session = _context.Sessions.FirstOrDefault(s => s.SessionId == id);
            if (session == null)
                throw new Exception("Session not found.");

            // Check if session is referenced in other tables
            bool isReferenced = _context.Students.Any(stu => stu.SessionId == id); // Add other relevant checks

            if (isReferenced)
                throw new Exception("Cannot delete session because it is in use.");

            _context.Sessions.Remove(session);
            _context.SaveChanges();
        }

    }
}
