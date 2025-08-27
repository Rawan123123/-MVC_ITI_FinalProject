using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Models;

namespace ProjectMVC.Controllers
{
    public class TopicController : Controller
    {
        ProjectContext context = new ProjectContext();

        public IActionResult Index()
        {
            List<Topic> topic = context.Topic
                .Include(t => t.Articals)
                .ToList();
            return View("Index" , topic);
        }
    }
}
