using System.Collections.Generic;
using System.Linq;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.Controllers
{
    public class RoleController
    {
        private readonly AppDbContext _context;

        public RoleController()
        {
            _context = new AppDbContext();
        }

        // ⭐ Get all roles
        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public List<Role> GetDefaultRolesOnly()
        {
            var defaultRoles = new List<string> { "SuperAdmin", "Admin", "Clerk" };
            return _context.Roles
                           .Where(r => defaultRoles.Contains(r.RoleName))
                           .ToList();
        }

        public List<Role> GetSpecificRolesOnly()
        {
            var defaultRoles = new List<string> { "Admin", "Clerk" };
            return _context.Roles
                           .Where(r => defaultRoles.Contains(r.RoleName))
                           .ToList();
        }

        // ⭐ Get a single role by ID
        public Role GetRoleById(int roleId)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleId == roleId)!;
        }

        // ⭐ Add a new role
        public Role AddRole(string roleName)
        {
            var existingRole = _context.Roles.FirstOrDefault(r => r.RoleName == roleName);
            if (existingRole != null)
            {
                throw new System.Exception("Role already exists.");
            }

            var newRole = new Role
            {
                RoleName = roleName
            };

            _context.Roles.Add(newRole);
            _context.SaveChanges();
            return newRole;
        }

        // ⭐ Update existing role
        public void UpdateRole(int roleId, string newRoleName)
        {
            var role = _context.Roles.FirstOrDefault(r => r.RoleId == roleId);
            if (role != null)
            {
                role.RoleName = newRoleName;
                _context.SaveChanges();
            }
        }

        // ⭐ Delete a role
        public void DeleteRole(int roleId)
        {
            var role = _context.Roles.FirstOrDefault(r => r.RoleId == roleId);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
        }
    }
}
