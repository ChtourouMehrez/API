using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class HeureSupplementaire
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CodeHeureSupplementaire { get; set; }
        [Required]
        public string Libelle { get; set; }
        public Decimal NBMax { get; set; }
        public Decimal Taux { get; set; }
        public string CodeHeureSuivant { get; set; }


    }
}
