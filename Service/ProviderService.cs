
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
    public class ProviderService : EntityService<Provider>, IProviderService
    {
        public ProviderService(IUnitOfWork utwk, IRepositoryBase<Provider> repository) : base(utwk, repository)
        {
        }
    }
}
