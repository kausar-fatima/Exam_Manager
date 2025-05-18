using System.Collections.Generic;
using System.Linq;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.Controllers
{
    public class SectionController
    {
        private readonly AppDbContext _context;

        public SectionController()
        {
            _context = new AppDbContext();
        }

        public Section AddSection(string sectionName)
        {
            var existing = _context.Sections.FirstOrDefault(s => s.SectionName == sectionName);
            if (existing != null)
                throw new System.Exception("Section already exists.");

            var section = new Section { SectionName = sectionName };
            _context.Sections.Add(section);
            _context.SaveChanges();
            return section;
        }

        public List<Section> GetAllSections()
        {
            return _context.Sections.ToList();
        }

        public Section GetSectionById(int id)
        {
            return _context.Sections.FirstOrDefault(s => s.SectionId == id)!;
        }

        public void UpdateSection(int id, string name)
        {
            var section = _context.Sections.FirstOrDefault(s => s.SectionId == id);
            if (section != null)
            {
                section.SectionName = name;
                _context.SaveChanges();
            }
        }

        public void DeleteSection(int id)
        {
            var section = _context.Sections.FirstOrDefault(s => s.SectionId == id);

            if (section == null)
                throw new Exception("Section not found.");

            // Check if session is referenced in other tables
            bool isReferenced = _context.Students.Any(stu => stu.SessionId == id); // Add other relevant checks

            if (isReferenced)
                throw new Exception("Cannot delete section because it is in use.");

            _context.Sections.Remove(section);
            _context.SaveChanges();
        }
    }
}
