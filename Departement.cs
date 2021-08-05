using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Departement
    {

        public int DepartementId { get; set; }
        [Required]
        [StringLength(100)]
        public String DepartementName { get; set; }
 
       

        public static explicit operator Task(Departement v)
        {
            throw new NotImplementedException();
        }
    }
}
