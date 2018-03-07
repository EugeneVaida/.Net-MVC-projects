using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UnitRepository
{
    public class Product
    {
        
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        [ForeignKey("Store")]
        public string StoreStoreName { get; set; }
        public Store Store { get; set; }
    }
}
