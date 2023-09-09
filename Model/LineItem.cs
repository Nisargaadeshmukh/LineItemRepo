using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLineItem.Model
{
    internal class LineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public LineItem(int id, int quantity, Product product)
        {
            Id = id;
            Quantity = quantity;
            Product = product;
        }

        public double CalculateLineItemCost()
        {
            double unitPrice = Product.calculateDiscountedPrice();
            return Quantity * unitPrice;
        }
    }
}