using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{
    public class InvestmentClientPoco
    {
        public virtual ClientPoco Client { get; set; }
        public virtual InvestmentPoco Investment { get; set; }
       // public long Id { get; set; }
        public short ClientOrder { get; set; }
       
    }
}
