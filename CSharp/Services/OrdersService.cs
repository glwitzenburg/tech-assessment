using CSharp.Interfaces;
using CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class OrdersService : IOrdersService
{
    static List<Orders> _orders = new List<Orders>
    {
                new Orders { Id = 0, Name = "a", Price = 2.00 },
                new Orders { Id = 1, Name = "b", Price = 3.00 },
                new Orders { Id = 2, Name = "c", Price = 4.00 },
                new Orders { Id = 3, Name = "d", Price = 5.00 },
                new Orders { Id = 4, Name = "e", Price = 6.00 },
                new Orders { Id = 5, Name = "f", Price = 7.00 },
                new Orders { Id = 6, Name = "g", Price = 8.00 },
                new Orders { Id = 7, Name = "h", Price = 9.00 },
            };

    public IEnumerable<Orders> GetAll()
    {
        return _orders;
    }

    public void Add(Orders order)
    {
        order.Id = _orders.Last().Id;
        _orders.Add(order);
    }

    public Orders GetById(int id) => _orders.FirstOrDefault(p => p.Id == id);

    public void Update(Orders order)
    {
        var index = _orders.FindIndex(p => p.Id == order.Id);
        if (index == -1)
            return;

        _orders[index] = order;
    }


    public void Cancel(int id)
    {
        var index = _orders.FindIndex(p => p.Id == id);
        _orders[index].Cancelled = true;
    }
}