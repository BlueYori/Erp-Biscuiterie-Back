using System;
using System.Collections.Generic;

namespace Erp_Biscuiterie_Back.Business.Models
{
    public partial class Reduction
    {
        public Reduction()
        {
            Customer = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public float Percentage { get; set; }

        public ICollection<Customer> Customer { get; set; }
    }
}
