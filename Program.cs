using CustomerLineItem.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLineItem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create products
            Product product1 = new Product(1, "product1", 100, 10);
            Product product2 = new Product(2, "product2", 150, 5);

            // Create LineItems
            LineItem lineItem1 = new LineItem(1, 2, product1);
            LineItem lineItem2 = new LineItem(2, 3, product2);

            // Create orders
            Order order1 = new Order(1, DateTime.Now);
            Order order2 = new Order(2, DateTime.Now); 

            order1.Items.Add(lineItem1);
            order1.Items.Add(lineItem2);
            order2.Items.Add(lineItem1);
            order2.Items.Add(lineItem2);

            // Create a customer
            Customer customer = new Customer(1, "John");
            customer.Orders.Add(order1);
            customer.Orders.Add(order2);

            // Display customer information
            Console.WriteLine($"CustomerId: {customer.Id}");
            Console.WriteLine($"Customer name: {customer.Name}");
            Console.WriteLine($"OrderCount: {customer.Orders.Count}");

        
            int orderNo = 1;
            foreach (var order in customer.Orders)
            {
                Console.WriteLine($"Order No{orderNo}:");
                Console.WriteLine($"Order Id: {order.Id}");
                Console.WriteLine($"Order Date: {order.Date.ToString("dd-MM-yyyy HH:mm:ss")}");

                Console.WriteLine("LineItemId ProductId ProductName Quantity UnitPrice Discount UnitCostAfterDiscount TotalLineItemCost");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");


                int lineItemId = 1;
                foreach (var item in order.Items)
                {
                    double unitPrice = item.Product.Price;
                    double discount = item.Product.DiscountPercent;
                    double unitCostAfterDiscount = item.CalculateLineItemCost();
                    double totalLineItemCost = item.CalculateLineItemCost();

                    Console.WriteLine($"{lineItemId} {item.Product.Id} {item.Product.Name} {item.Quantity} {unitPrice} {discount}% {unitCostAfterDiscount} {totalLineItemCost}");
                    lineItemId++;
                }

                double orderCost = order.CalculateOrderPrice();       
                Console.WriteLine($"Order Cost: {orderCost}");
                Console.WriteLine();

                orderNo++;
            }
        }
    }
}
    





