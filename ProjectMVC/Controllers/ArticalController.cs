using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Models;
using ProjectMVC.ViewModel;
using ProjectMVC.ViewModel;

namespace ProjectMVC.Controllers
{
    public class ArticalController : Controller
    {
        ProjectContext context = new ProjectContext();

        public IActionResult Index()
        {
            List<Artical> articals = context.Artical
                .Include(a => a.Dept)
                .Where(a => !a.IsDeleted)
                .Include(a => a.topic)
                .Include(a => a.ArticalsAuthors).ThenInclude(aa => aa.authoer)
                .OrderByDescending(a => a.ArticalsAuthors.Max(aa => (DateTime?)aa.PublishDate) ?? DateTime.MinValue)

                .ToList(); 

            return View("Index", articals);
        }

        public IActionResult Add()
        {
            AtricalImagesDeptsViewModel articalVM = new AtricalImagesDeptsViewModel();
            articalVM.Dept = context.Department.ToList();
            articalVM.topic = context.Topic.ToList();
            articalVM.authoer = context.Author.ToList();    


            return View("Add" , articalVM);
        }
       
         [HttpPost]
        public IActionResult SaveAdd(AtricalImagesDeptsViewModel ArticalDB)
        {

            if (ArticalDB.Name != null && ArticalDB.ImgURL!=null)
            {
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", ArticalDB.ImgURL);

                if (System.IO.File.Exists(imagePath))
                {
                    Artical newArtical = new Artical
                    {
                        Name = ArticalDB.Name,
                        ImgURL = ArticalDB.ImgURL,
                        DepartmentId = ArticalDB.DepartmentId,
                        TopicId = ArticalDB.TopicId,
                    };

                    context.Artical.Add(newArtical);
                    context.SaveChanges();

                    AuthorsArticlas relation = new AuthorsArticlas
                    {
                        ArticalId = newArtical.Id,
                        AuthorId = ArticalDB.AuthorId
                    };

                    context.AuthorsArticlas.Add(relation);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ArticalDB.Dept = context.Department.ToList();
            ArticalDB.topic = context.Topic.ToList();
            ArticalDB.authoer = context.Author.ToList();
            return View("Add", ArticalDB);
        }

        public IActionResult Delete(int id)
        {
            var Artical = context.Artical.FirstOrDefault(a => a.Id == id);
            if (Artical != null)
            {
                Artical.IsDeleted = true;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
