﻿using System;
using System.Collections.Generic;
using Erp_Biscuiterie_Back.Business.Helpers;
using Newtonsoft.Json;

namespace Erp_Biscuiterie_Back.Business.Models
{
    public partial class Role
    {
        public Role()
        {
            ShouldSerializeContractResolver s = new ShouldSerializeContractResolver();

            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> User { get; set; }

    }
}
