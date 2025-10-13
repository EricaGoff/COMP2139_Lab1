using COMP2139_Lab1.Data;
using COMP2139_Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Lab1.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tasks = _context.ProjectTasks.Include(t => t.Project).ToList();
            return View(tasks);
        }

        public IActionResult Create()
        {
            ViewBag.Projects = _context.Projects.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                // ✅ Fix for PostgreSQL timestamp issue
                projectTask.StartDate = DateTime.SpecifyKind(projectTask.StartDate, DateTimeKind.Utc);
                projectTask.EndDate = DateTime.SpecifyKind(projectTask.EndDate, DateTimeKind.Utc);

                _context.ProjectTasks.Add(projectTask);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(projectTask);
        }
    }
}