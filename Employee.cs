using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Employee
    {

        public int EmployeeId { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        [Required]
        public String Email { get; set; }

        public DateTime DateOfBirthday { get; set; }
        public String Photo { get; set; }
        public String DepartementId { get; set; }
        public Gender Gender { get; set; }
        public Departement Departement { get; set; }


    }

    public enum Gender { Male, Femele }


}
