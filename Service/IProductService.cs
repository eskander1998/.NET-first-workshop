using GP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using GP.ServicePattern;

namespace GP.Service
{
    public interface IProductService : IEntityService<Product>
    {
        public IEnumerable<Product> GetProductByName(string Name);
        public int GetClientNbre(int productid);
    }
}
