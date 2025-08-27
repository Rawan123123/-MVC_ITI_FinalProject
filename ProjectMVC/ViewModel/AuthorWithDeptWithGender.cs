using ProjectMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMVC.ViewModel
{
    public class AuthorWithDeptWithGender
    {
        public int Id { get; set; }
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

        public int DepartmentId { get; set; }

        public List<Department> Dept { get; set; }
        public List<Gender> Genders { get; set; }  


    }
}
