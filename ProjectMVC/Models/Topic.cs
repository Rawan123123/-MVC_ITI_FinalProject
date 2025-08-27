using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class Topic
    {
        public int Id { get; set; }
        [MaxLength(100)]

        public string Name { get; set; }

        public List<Artical> Articals { get; set; }
    }
}

