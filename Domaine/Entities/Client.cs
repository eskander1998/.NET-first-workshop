using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain.Entities
{
   public  class Client
    { 
        [Key]
        public int Cin { get; set; }
        public String Prenom { get; set; }
        public String Nom { get; set; }
        public String Email { get; set; }

        public virtual ICollection<Facture> Factures { get; set; }

    }
}
