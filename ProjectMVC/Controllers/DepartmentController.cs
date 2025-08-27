using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Models;

namespace ProjectMVC.Controllers
{
    public class DepartmentController : Controller
    {
        ProjectContext context = new ProjectContext();

        public IActionResult Index()
        {
            List<Department> departments = context.Department
                .Include(d => d.Authors)
                .Include(d =>d.Articals)
                .Where(d => !d.IsDeleted)
                .OrderBy(d => d.DateOfCreation)        
                .ToList();
            return View("Index", departments);
        }
        public IActionResult Delete(int id)
        {
            var department = context.Department.FirstOrDefault(d => d.Id == id);
            if (department != null)
            {
                department.IsDeleted = true;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
