using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{
    public class ClientAddressPoco : AddressPoco
    {
        public virtual ICollection<ClientPoco> Clients { get; set; }
    }
}
