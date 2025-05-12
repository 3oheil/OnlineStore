using OnlineStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
    }
}
