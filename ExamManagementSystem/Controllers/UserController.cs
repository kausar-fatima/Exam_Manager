using System.Collections.Generic;
using System.Linq;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.Controllers
{
    public class UserController
    {
        private readonly AppDbContext _context;

        public UserController()
        {
            _context = new AppDbContext();
        }

        public void AddUser(string username, string password, string role)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == username);
            if (existingUser != null)
            {
                throw new System.Exception("Username already exists. Please choose a different one.");
            }

            var newUser = new User
            {
                Username = username,
                PasswordHash = password, // In real projects, always hash passwords
                Role = role
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public User AuthenticateUser(string username, string password)
        {
            var user = _context.Users
                               .FirstOrDefault(u => u.Username == username && u.PasswordHash == password);
            return user!;
        }

        // ⭐ NEW METHOD - Get all users except the current logged-in user
        public List<User> GetAllUsersExcept(int currentUserId)
        {
            return _context.Users
                           .Where(u => u.UserId != currentUserId && u.Username != "SuperAdmin")
                           .ToList();
        }

        // ⭐ NEW METHOD - Get a single user by ID
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id)!;
        }

        // ⭐ NEW METHOD - Update user
        public void UpdateUser(int id, string username, string password, string role)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                user.Username = username;
                user.PasswordHash = password; // Again, ideally use hashing
                user.Role = role;

                _context.SaveChanges();
            }
        }

        // ⭐ NEW METHOD - Delete user
        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
