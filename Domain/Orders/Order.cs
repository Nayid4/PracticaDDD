using Domain.Customers;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class Order
    {
        private readonly HashSet<LineItem> _lineItem = new();

        public OrderId Id { get; private set; }

        public CustomerId CustomerId { get; private set; }

        public IReadOnlyList<LineItem> LineItems => _lineItem.ToList();

        public static Order Create(CustomerId customerId)
        {
            var order = new Order
            {
                Id = new OrderId(Guid.NewGuid()),
                CustomerId = customerId
            };

            return order;
        }

        public void Add(ProductId productId, Money price)
        {
            var lineItem = new LineItem(new LineItemId(Guid.NewGuid()), Id, productId, price);

            _lineItem.Add(lineItem);
        }

    }
}
