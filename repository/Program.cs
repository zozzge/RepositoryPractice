using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    class Program
    {

        public void AddProduct(Repository<Product> productRepository,string productName,string productCode,int productPrice)
        {

            bool productExists = productRepository.ListAll().Where(p => p.Name== productName).FirstOrDefault() != null;

            if (!productExists)
            {
                Product newProduct = new Product
                {
                    Name = productName,
                    Code = productCode,
                    Price = productPrice
                };

                productRepository.Save(newProduct);
            }
        }

        public void AddCustomer(Repository<Customer> customerRepository, string customerFullName, string customerIdNo, string customerEMail)
        {

            bool customerExists = customerRepository.ListAll().Where(c => c.FullName == customerFullName).FirstOrDefault() != null;

            if (!customerExists)
            {
                Customer newCustomer = new Customer
                {
                    FullName = customerFullName,
                    IdNo=customerIdNo,
                    EMail=customerEMail
                };

                customerRepository.Save(newCustomer);
            }
        }

        public void ShowOrderDetails(OrderRepository orderRepository,Repository<OrderItem> orderItemRepository,Repository<Customer> customerRepository,Repository<Product> productRepository, int orderId)
        {
            Order order = orderRepository
                .WithDetails()
                .Where(o => o.Id == orderId)
                .FirstOrDefault();

            Customer customer = customerRepository.GetById(order.CustomerId);

            Console.WriteLine("Order ID: " + order.Id);
            Console.WriteLine("Customer Name: " + customer.FullName);
            Console.WriteLine();

            Console.WriteLine("Order Items:");

            if (order.Items == null || order.Items.Count == 0)
            {
                Console.WriteLine("No items in this order.");
            }
            else
            {
                foreach (OrderItem item in order.Items)
                {
                    Product product = productRepository.GetById(item.ProductId);

                    Console.WriteLine("Product Name: " + product?.Name); 
                    Console.WriteLine("Quantity: " + item.Quantity);
                    Console.WriteLine("Price per Unit: " + item.Price);
                    Console.WriteLine("Total Price: " + (item.Quantity * item.Price));
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Total Order Price: " + order.Total);
        }
        static void Main(string[] args)
        {
            AppDbContext dbContext = new AppDbContext();

            //dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();


            Repository<Product> productRepository = new Repository<Product>(dbContext);
            Repository<Customer> customerRepository = new Repository<Customer>(dbContext);

            OrderRepository orderRepository = new OrderRepository(dbContext);
            Repository<OrderItem> orderItemRepository = new Repository<OrderItem>(dbContext);

            Program program = new Program();

            program.AddCustomer(customerRepository, "Hale Dirikgil", "87649039823", "hmdirikgil@gmail.com");
            program.AddProduct(productRepository, "Dalin", "Ax65940", 50);

            program.AddProduct(productRepository, "Elma", "YU6754", 20);
            program.AddProduct(productRepository, "Sivri Biber", "SB5656", 25);
            program.AddProduct(productRepository, "Hale Domatesi", "HD87654", 150);

            program.ShowOrderDetails(orderRepository, orderItemRepository, customerRepository, productRepository,1);

            var biber = productRepository.GetById(3);
            var domates = productRepository.GetById(4);

            /*var order = new Order();
            order.CustomerId = 1;
            order.OrderTime = DateTime.Now;
            order.AddItem(biber.Id, 15, biber.Price);
            order.AddItem(domates.Id, 3, domates.Price);

            orderRepository.Save(order);*/

            //içinde n geçen ürünler

            /*var products = productRepository.ListAll().Where(p => p.Name.Contains("n")).ToList();

            foreach (var product in products)
            {
                Console.WriteLine(product.Name + "-->" + product.Id);
            }*/



            //updating

            /*var customer = customerRepository.GetById(1);

            if (customer != null)
            {
                Console.WriteLine(customer.FullName);

                customer.IdNo = "xoxoxoxoxo";
                customerRepository.Update(customer);

            }
            else
            {
                Console.WriteLine("Customer cannot be found in database");
            }*/




            //var customers =
            //    customerRepository.
            //    ListAll().
            //    Where(c => c.FullName.Contains("gil")).ToList();

            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer.FullName + "-->" + customer.EMail);
            //}




            Console.WriteLine("All works fine!");
        }
    }
}
