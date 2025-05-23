﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class OrderItem
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long Quantity { get; set; }

        public Order? Order { get; set; }

        public long ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
