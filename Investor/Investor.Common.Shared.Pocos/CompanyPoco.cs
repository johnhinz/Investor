using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{
    public class CompanyPoco
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }

        //public long AddressId{get; set;}
        public string PhoneNumber { get; set; }
        public string AgentId { get; set; }
        public virtual ICollection<CompanyAddressPoco> Addresses { get; set; }
    }
}
