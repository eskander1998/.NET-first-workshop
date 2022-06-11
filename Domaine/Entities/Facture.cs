using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain.Entities
{
    public class Facture
    {
        //[Key(),Column(Order =0)]
        //[DataType(DataType.Date)]
        

        //[Key(), Column(Order = 1)]
        public int ProductFk { get; set; }

        //[ForeignKey("Productid")]
        public virtual Product Product { get; set; }
        //[Key, Column(Order = 2)]
               
        public int ClientFk { get; set; }
        //[ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        public DateTime DateAchat { get; set; }
        public float Prix { get; set; }

    }
}
