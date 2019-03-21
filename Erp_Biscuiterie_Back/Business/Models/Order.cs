using System;
using System.Collections.Generic;

namespace Erp_Biscuiterie_Back.Business.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int StateId { get; set; }

        public Customer Customer { get; set; }
        public State State { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
