using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLineItem.Model
{
    internal class Customer
    {  // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
            Orders = new List<Order>();
        }
    }
}