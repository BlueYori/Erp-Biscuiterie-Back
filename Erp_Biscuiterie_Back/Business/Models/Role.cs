using System;
using System.Collections;
using System.Collections.Generic;

namespace Erp_Biscuiterie_Back.Business.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> User { get; set; }
    }
}
