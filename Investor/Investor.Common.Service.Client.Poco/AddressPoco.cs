﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Service.Client.Poco
{
    public class AddressPoco
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Postal_Code { get; set; }
        public virtual ICollection<ClientPoco> Clients {get;set;}
    }
}
