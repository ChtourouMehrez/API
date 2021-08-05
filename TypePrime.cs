using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class TypePrime
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CodePrime { get; set; }
        [Required]
        public string Libelle { get; set; }
        public Boolean Cotisable { get; set; }

        public Boolean Imposable { get; set; }

        public Boolean Fixe { get; set; }
        public Boolean PointageNormal { get; set; }

        public Boolean Horaire { get; set; }
        public Boolean PriseConsideration { get; set; }




    }
}
