using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMVC.Models
{
    
        public class Author
        {
            public int Id { get; set; }
            [Display(Name="Author")]
            public string Name { get; set; }
            public DateTime DOB { get; set; }

            [NotMapped]
            public int Age
            {
                get
                {
                    var today = DateTime.Today;
                    var age = today.Year - DOB.Year;
                    if (DOB.Date > today.AddYears(-age)) age--;
                    return age;
                }
            }


            [MaxLength(100)]
            public string Address { get; set; }
            public Gender Gender { get; set; }
            public int Salary { get; set; }

            [Display(Name = "Department")]

            public int DepartmentId { get; set; }

            [ForeignKey("DepartmentId")]
            public Department Dept { get; set; }
            public bool IsDeleted { get; set; }


        public ICollection<AuthorsArticlas> AuthorsArticlas { get; set; }

        }
        public enum Gender
        {
            Male=0,
            Female=1
        }
    
}

