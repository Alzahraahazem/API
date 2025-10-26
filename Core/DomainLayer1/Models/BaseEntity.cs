using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer1.Models
{
    public class BaseEntity<Tkey>
    {
        public  Tkey Id { get; set; } //pk
    }
}
