using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{
    [DataContract]
    public class CompanyPhoneNumberPoco
    {
        [DataMember]
        public long PhoneNumberId { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public PhoneNumberEnum PhoneType { get; set; }
        public virtual ICollection<CompanyPoco > Companies { get; set; }

    }
}
