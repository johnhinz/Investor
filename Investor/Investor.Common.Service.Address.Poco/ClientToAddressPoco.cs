using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Service.Address.Poco
{
    class ClientToAddressPoco
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long AddressId { get; set; }
    }
}
