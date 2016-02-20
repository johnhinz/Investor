using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Service.Investment.Poco
{
    public class InvestmentPoco
    {
        public long Id { get; set; }
        public string InvestmentType { get; set; }

        public long CompanyId { get; set; }
    }
}
