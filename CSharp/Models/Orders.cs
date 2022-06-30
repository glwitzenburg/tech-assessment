using System;

namespace CSharp.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Cancelled { get; set; } = false;
    }
}
