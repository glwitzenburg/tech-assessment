using CSharp.Models;
using System;
using System.Collections.Generic;

namespace CSharp.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<Orders> GetAll();
        void Add(Orders order);
        Orders GetById(int id);
        void Update(Orders order);
        void Cancel(int id);
    }
}
