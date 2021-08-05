using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Qualification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CodeQualification { get; set; }
        [Required]
        public string Libelle { get; set; }
    }
}
