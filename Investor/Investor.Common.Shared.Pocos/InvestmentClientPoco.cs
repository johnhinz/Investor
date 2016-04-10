using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{
    public class InvestmentClientPoco
    {
        public long ClientId { get; set; }
        public long InvestmentId { get; set; }
        public short ClientOrder { get; set; }
        public virtual ICollection<ClientPoco> Clients { get; set; }
    }
}
