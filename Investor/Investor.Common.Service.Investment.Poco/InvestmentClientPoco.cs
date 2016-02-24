using Investor.Common.Service.Client.Poco;
using System.Collections.Generic;

namespace Investor.Common.Service.Investment.Poco
{
    public class InvestmentClientPoco
    {
        public virtual ICollection<ClientPoco> Clients { get; set; }
        public virtual InvestmentPoco Investment { get; set; }
        public short ClientOrder { get; set; }
    }
}
