using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{
    [DataContract]
    public class CompanyPoco
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string ContactName { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string AgentId { get; set; }
        public virtual ICollection<CompanyAddressPoco> Addresses { get; set; }
        public virtual ICollection <CompanyPhoneNumberPoco > PhoneNumbers { get; set; }

    }
}
