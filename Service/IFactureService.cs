using GP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using GP.ServicePattern;

namespace GP.Service
{
    public interface IFactureService : IEntityService<Facture>
    {
        public IEnumerable<Facture> GetFactureByPrice(string prix);
    }
}
