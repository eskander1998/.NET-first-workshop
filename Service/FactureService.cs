
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using GP.Data;
using GP.Data.Infrastructure;
using GP.Domain.Entities;
using GP.ServicePattern;



namespace GP.Service
{
    public class FactureService : EntityService<Facture>, IFactureService
    {
        public FactureService(IUnitOfWork utwk, IRepositoryBase<Facture> repository) : base(utwk, repository)
        {
        }

        public IEnumerable<Facture> GetFactureByPrice(string prix)
        {
            return this.GetMany().Where(m => m.Prix >= float.Parse(prix));
        }
    }
}
