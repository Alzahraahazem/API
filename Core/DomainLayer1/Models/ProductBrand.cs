using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer1.Models
{
    public class ProductBrand : BaseEntity<int>
    {
        public string Name { get; set; } = null!;

    }
}
