using ProjectMVC.Models;

namespace ProjectMVC.ViewModel
{
    public class AtricalImagesDeptsViewModel
    {
        public string? Name { get; set; }
        public string ImgURL { get; set; }

        public int DepartmentId { get; set; }
        public List<Department> Dept { get; set; }

        public int TopicId { get; set; }
        public List<Topic> topic { get; set; }

        public int AuthorId { get; set; }
        public List<Author> authoer { get; set; }



    }
}
