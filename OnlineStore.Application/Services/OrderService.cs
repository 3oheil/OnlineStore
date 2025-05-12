using OnlineStore.Application.Interfaces;
using OnlineStore.Application.Models;
using OnlineStore.Application.Repositories;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Order> _orderRepository;

        public OrderService(
            IRepository<Customer> customerRepository, IRepository<Product> productRepository,
            IRepository<Order> orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task PlaceOrderAsync(OrderDto dto)
        {
            var customer =await _customerRepository.GetByIdAsync(dto.CustomerId) ??  // Checking existence and validity of the user
                throw new Exception("customer Not Found");

            var products= await _productRepository.GetAllAsync();
            var orderItems = new List<OrderItem>();

            foreach(var item in dto.Items)
            {
                var product = products.FirstOrDefault(x => x.Id == item.ProductId) ??
                    throw new Exception($"Product with {item.ProductId} was Not Found");

                orderItems.Add(new OrderItem
                {
                    ProductId = product.Id,
                    Product = product,
                    Quantity = item.Quantity,
                });
            }

            var totalPrice = orderItems.Sum(i=>i.Product.Price * i.Quantity);
            if (totalPrice < 50000)
                throw new Exception("Order total most be at least 50000");

            var now = DateTime.Now.TimeOfDay;
            if (now < TimeSpan.FromHours(8) || now > TimeSpan.FromHours(19))
                throw new Exception("Orders can only be placed between 08:00 and 19:00");
            
            var hasFrgile = orderItems.Any(x=>x.Product.Type == ProductType.Fragile);
            var shipping = hasFrgile? ShippingMethod.Express : ShippingMethod.Regular;

            var order = new Order
            {
                CustomerId = customer.Id,
                Customer = customer,
                Items = orderItems,
                CreateAt = DateTime.Now,
                ShippingMethod = shipping,
            };

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();
        }
    }
}
