using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class AuthorsArticlas
    {
        [Display(Name ="Author")] 
        
        public int AuthorId { get; set; }
        public Author authoer { get; set; }
        [Display(Name = "Artical")]

        public int ArticalId { get; set; }
        public Artical artical { get; set; }


        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "01/01/2000", "12/31/2099", ErrorMessage = "Article must be published after 2000")]
        public DateTime PublishDate { get; set; }
    }
}
