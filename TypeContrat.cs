using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Models
{
    public class TypeContrat
    {
        [Key]
        public int Id { get; set; }

        public string CodeTypeContrat { get; set; }
        public String Libelle { get; set; }
        public Boolean CompterAnciente { get; set; }
      
    }
}
