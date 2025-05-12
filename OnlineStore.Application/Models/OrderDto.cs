using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Models
{
    public class OrderDto
    {
        public int CustomerId { get; set; }
        public List<OrderItemDto>? Items { get; set; }
    }
}
