using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Models;
using ProjectMVC.ViewModel;

namespace ProjectMVC.Controllers
{
    public class AuthorController : Controller
    {
        ProjectContext context = new ProjectContext();
        public IActionResult Index()
        {
            List<Author> authors = context.Author
                .Include(a =>a.Dept)
                .Where(a => !a.IsDeleted)
                .ToList();
            return View("Index", authors);
        }
        public IActionResult Add()
        {
            ViewBag.Genders = Enum.GetValues(typeof(Gender))
                           .Cast<Gender>()
                           .Select(g => new SelectListItem
                           {
                               Value = g.ToString(),
                               Text = g.ToString()
                           }).ToList();
            ViewData["DeptList"] = context.Department.ToList();


            return View("Add");
        }

        public IActionResult SaveAdd(Author author)
        {
            if (author?.Name != null && author?.Age >= 20 && author?.Age <= 50 && (author?.Address.ToLower() =="cairo" || author?.Address.ToLower()=="giza"))
            {
                context.Add(author);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Genders = Enum.GetValues(typeof(Gender))
                           .Cast<Gender>()
                           .Select(g => new SelectListItem
                           {
                               Value = g.ToString(),
                               Text = g.ToString()
                           }).ToList();
            ViewData["DeptList"] = context.Department.ToList();
            return View("Add" , author);

        }

        public IActionResult Edit(int id)
        {
            Author authorModel = context.Author.FirstOrDefault(a => a.Id == id);
            List<Department> deptList = context.Department.ToList();
            AuthorWithDeptWithGender AuthViewModel = new AuthorWithDeptWithGender();

                AuthViewModel.Id = authorModel.Id;
                AuthViewModel.Name = authorModel.Name;
                AuthViewModel.Salary = authorModel.Salary;
                AuthViewModel.Address = authorModel.Address;
                AuthViewModel.Gender = authorModel.Gender;
                AuthViewModel.DOB = authorModel.DOB;

                AuthViewModel.Dept = deptList;
                AuthViewModel.Genders = Enum.GetValues<Gender>().ToList();

                return View("Edit", AuthViewModel);

        }

        public IActionResult SaveEdit(AuthorWithDeptWithGender authorFromRequest,int id)
        {
            if (authorFromRequest?.Name != null && authorFromRequest?.Age >= 20 && authorFromRequest?.Age <= 50 && (authorFromRequest?.Address.ToLower() == "cairo" || authorFromRequest?.Address.ToLower() == "giza"))
            {
                Author authorDB = context.Author.FirstOrDefault(a => a.Id == id);

                authorDB.Name = authorFromRequest.Name;
                authorDB.Address = authorFromRequest.Address;
                authorDB.DOB = authorFromRequest.DOB;
                authorDB.Salary = authorFromRequest.Salary;
                authorDB.DepartmentId = authorFromRequest.DepartmentId;
                authorDB.Gender = authorFromRequest.Gender;

                context.SaveChanges();
                return RedirectToAction("Index");

            }
            authorFromRequest.Dept = context.Department.ToList();
            authorFromRequest.Genders = Enum.GetValues<Gender>().ToList();

            return View("Edit", authorFromRequest);
        }

        public IActionResult Delete(int id)
        {
            var author = context.Author.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                author.IsDeleted = true; 
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
