
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
    public class ClientService : EntityService<Client>, IClientService
    {
        public ClientService(IUnitOfWork utwk, IRepositoryBase<Client> repository) : base(utwk, repository)
        {
        }

        public float GetTotalFacturePrice(int clientid)
        {
            //var client = this.GetMany().Where(m => m.Cin == clientid).FirstOrDefault();
            var client = this.GetById(clientid);
            var listfactures = client.Factures.ToList();

            float sommeprix = 0;

            foreach (var fact in listfactures)
            {
                sommeprix += fact.Prix;
            }

            return sommeprix;
        }
    }
}
