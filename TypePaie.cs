using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Models
{
    public class TypePaie
    {
        [Key]
        public int Id { get; set; }

        public string codePaie { get; set; }
        public Boolean Declarer { get; set; }
        public Boolean PECPointage { get; set; }
        public bool PECNote { get; set; }
        public Boolean PECPrime { get; set; }
        public Boolean AutreCalcule { get; set; }
    }
}
