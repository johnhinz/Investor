using System.Collections.Generic;

namespace Investor.Common.Shared.Pocos
{
    public class CompanyPoco
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string AgentId { get; set; }
        public virtual ICollection<CompanyAddressPoco> Addresses { get; set; }
        public virtual ICollection <CompanyPhoneNumberPoco > PhoneNumbers { get; set; }

    }
}
