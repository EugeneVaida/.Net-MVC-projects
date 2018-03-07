using System.Collections.Generic;
using System.Linq;
using Domain.UnitRepository;
using System.Data.Entity;

namespace Domain
{
    public class Repository
    {
        private StoreSolutionDbContext context;
        
        public Repository()
        {
            context = new StoreSolutionDbContext();
        }

        public IEnumerable<Store> GetStores()
        {            
            return context.Stores.ToList();
        }

        public IEnumerable<Product> GetStoreProducts(string id)
        {
            var products = context.Products.Include(p => p.Store).ToList().Where(x => x.StoreStoreName.Contains(id)).ToList();
            return products;
        }
    }
}
