using Microsoft.AspNetCore.Mvc;
using COMP2139_Lab1.Data;
using COMP2139_Lab1.Models;
using Microsoft.EntityFrameworkCore; // 👈 Add this for Include()
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

        // GET: Projects
        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();
            return View(projects);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Details/5
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