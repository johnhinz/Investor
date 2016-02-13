using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Service.Company.Poco
{
    public class CompanyPoco
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }

        //public long AddressId{get; set;}
        public long PhoneNumber { get; set; }
        public long AgentID { get; set; }
    }
}
