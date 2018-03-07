using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.UnitRepository;

namespace Domain
{
    class StoreSolutionDbContext : DbContext
    {        
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
