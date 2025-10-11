using Microsoft.AspNetCore.Mvc;
using COMP2139_Lab1.Models;
using System.Collections.Generic;
using System.Linq;

namespace COMP2139_Lab1.Controllers
{
    public class ProjectsController : Controller
    {
        private static List<Project> Projects = new List<Project>();

        public IActionResult Index()
        {
            return View(Projects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                project.Id = Projects.Count + 1;
                Projects.Add(project);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        public IActionResult Details(int id)
        {
            var project = Projects.FirstOrDefault(p => p.Id == id);
            if (project == null) return NotFound();
            return View(project);
        }
    }
}