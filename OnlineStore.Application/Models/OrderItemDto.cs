using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Models
{
    public class OrderItemDto
    {
        public long ProductId { get; set; }
        public long Quantity { get; set; }
    }
}