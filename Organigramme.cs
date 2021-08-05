using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Organigramme
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Code { get; set; }
        [Required]
        public String Libelle { get; set; }
    }
}
