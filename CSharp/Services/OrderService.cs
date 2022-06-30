using CSharp.Models;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Services
{
    public static class OrderService
    {
        static List<Order> Orders { get; }
        static int nextId = 3;
        static OrderService()
        {
            Orders = new List<Order>
            {
                new Order { Id = 0, Name = "a", Price = 2.00 },
                new Order { Id = 1, Name = "b", Price = 3.00 },
                new Order { Id = 2, Name = "c", Price = 4.00 },
                new Order { Id = 3, Name = "d", Price = 5.00 },
                new Order { Id = 4, Name = "e", Price = 6.00 },
                new Order { Id = 5, Name = "f", Price = 7.00 },
                new Order { Id = 6, Name = "g", Price = 8.00 },
                new Order { Id = 7, Name = "h", Price = 9.00 },
            };
        }

        public static List<Order> GetAll() => Orders;

        public static Order? Get(int id) => Orders.FirstOrDefault(p => p.Id == id);

        
        public static void Add(Order order)
        {

            order.Id = Orders.Last().Id;
            Orders.Add(order);
        }

        public static void Update(Order order)
        {
            var index = Orders.FindIndex(p => p.Id == order.Id);
            if (index == -1)
                return;

            Orders[index] = order;
        }

        public static void Delete(int id)
        {
            var order = Get(id);
            if (order is null)
                return;

            Orders.Remove(order);
        }
    }
}
