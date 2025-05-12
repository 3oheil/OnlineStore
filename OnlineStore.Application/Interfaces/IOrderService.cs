using OnlineStore.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Interfaces
{
    public interface IOrderService
    {
        Task PlaceOrderAsync(OrderDto order);
    }
}
