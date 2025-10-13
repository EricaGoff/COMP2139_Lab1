using Microsoft.AspNetCore.Mvc;
using COMP2139_Lab1.Data;
using COMP2139_Lab1.Models;
using Microsoft.EntityFrameworkCore; 
using System.Linq;

namespace COMP2139_Lab1.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();
            return View(projects);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                
                project.StartDate = DateTime.SpecifyKind(project.StartDate, DateTimeKind.Utc);
                project.EndDate = DateTime.SpecifyKind(project.EndDate, DateTimeKind.Utc);

                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }
        
        public IActionResult Details(int id)
        {
            var project = _context.Projects
                .Include(p => p.ProjectTasks)
                .FirstOrDefault(p => p.Id == id);

            if (project == null)
                return NotFound();

            return View(project);
        }
    }
}