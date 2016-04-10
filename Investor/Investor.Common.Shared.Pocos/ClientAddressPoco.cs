using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{
    [DataContract]
    public class ClientAddressPoco 
    {
        [DataMember]
        public long AddressId { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Province { get; set; }
        [DataMember]
        public string Postal_Code { get; set; }
        public virtual ICollection<ClientPoco> Clients { get; set; }
    }
}
