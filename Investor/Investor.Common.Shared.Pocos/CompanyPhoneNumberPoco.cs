using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{
    public class CompanyPhoneNumberPoco
    {
        public long PhoneNumberId { get; set; }
        public string PhoneNo { get; set; }
        public PhoneNumberEnum PhoneType { get; set; }
        public virtual ICollection<CompanyPoco > Companies { get; set; }

    }
}
