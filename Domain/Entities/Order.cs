using OnlineStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public DateTime CreateAt { get; set; }

        public Customer? Customer { get; set; }
        public List<OrderItem>? Items { get; set; }

        public ShippingMethod ShippingMethod { get; set; }

        public decimal TotalPrice => Items.Sum(i=>i.Product.Price * i.Quantity); 
    }
}
