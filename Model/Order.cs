using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLineItem.Model
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<LineItem> Items { get; set; }

        public Order(int id, DateTime date)
        {
            Id = id;
            Date = date;
            Items = new List<LineItem>();
        }

        public double CalculateOrderPrice()
        {
            double totalOrderCost = 0;
            foreach (var item in Items)
            {
                totalOrderCost += item.CalculateLineItemCost();
            }
            return totalOrderCost;
        }
    }
}


