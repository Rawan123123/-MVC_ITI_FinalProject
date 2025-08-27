namespace ProjectMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? DateOfCreation { get; set; }

        public List<Author> Authors { get; set; }

        public List<Artical> Articals { get; set; }

        public bool IsDeleted { get; set; }

    }
}
