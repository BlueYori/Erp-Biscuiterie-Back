using System;
using System.Collections.Generic;

namespace Erp_Biscuiterie_Back.Business.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DirectorName { get; set; }
        public string DepartmentName { get; set; }
        public int ReductionId { get; set; }

        public Reduction Reduction { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
