using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
  
    public class EditEmployeeModel
    {

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public String FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public String LastName { get; set; }
        [Required]

        [EmailDomainValidator(AllowedDomain = "Domaine.com")]
        public string Email { get; set; }
        [Compare(nameof(Email), ErrorMessage = "Emails mismatch")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public String Photo { get; set; }
        public String DepartementId { get; set; }
        public Gender Gender { get; set; }
        public Departement Departement { get; set; }


    }


}
