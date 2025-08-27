using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class Artical
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? ImgURL { get; set; }

        public int DepartmentId { get; set; }
        public Department Dept { get; set; }

        [Display(Name = "Topic")]
        public int TopicId { get; set; }
        public Topic topic { get; set; }
        public bool IsDeleted { get; set; }


        public ICollection<AuthorsArticlas> ArticalsAuthors { get; set; }


    }
}
