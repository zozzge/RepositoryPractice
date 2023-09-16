using System;
using System.Collections.Generic;
using System.Text;

namespace repository
{
    public class Order:EntityBase
    {

        public Order()
        {
            Items = new List<OrderItem>();
        }

        public int CustomerId { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal Total { get; set; }

        public ICollection<OrderItem> Items { get; set; }


        public void AddItem(int productId, decimal quantity, decimal price)
        {
            if (productId < 1)
            {
                throw new Exception("Product Id should be greater than zero!");
            }
            if (quantity <= 0)
            {
                throw new Exception("Quantity should be greater than zero!");
            }

            Items.Add(
                new OrderItem()
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = price
                }
            );

            Total = Total + (price * quantity);

        }

    }

    public class OrderItem: EntityBase
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public Order Order { get; set; }
    }

}
