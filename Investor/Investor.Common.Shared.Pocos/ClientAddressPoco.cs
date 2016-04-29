using System.Collections.Generic;

namespace Investor.Common.Shared.Pocos
{
    public class ClientAddressPoco 
    {
        public long AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Postal_Code { get; set; }
        public virtual ICollection<ClientPoco> Clients { get; set; }
    }
}
