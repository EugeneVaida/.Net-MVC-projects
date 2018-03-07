using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UnitRepository
{
    public class Store
    {
        [Key]
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string WorkTime { get; set; }

        public ICollection<Product> Products { get; set; }
        public Store()
        {
            Products = new List<Product>();
        }
    }
}
