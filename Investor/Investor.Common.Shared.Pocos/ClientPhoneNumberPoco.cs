using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{

    public enum PhoneNumberEnum
    {
        Cell,
        Work,
        Home,
        Fax
    }

    [DataContract]
    public class ClientPhoneNumberPoco
    {
        [DataMember]
        public long PhoneNumberId { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public PhoneNumberEnum PhoneType { get; set; }
        public virtual ICollection <ClientPoco > Clients { get; set; }

    }
}
