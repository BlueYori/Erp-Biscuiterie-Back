using System;
using System.Collections.Generic;

namespace Erp_Biscuiterie_Back.Business.Models
{
    public partial class ProductDisponibility
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
