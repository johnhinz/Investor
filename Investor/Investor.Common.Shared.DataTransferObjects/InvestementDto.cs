using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.DataTransferObjects
{
    public class InvestmentDto
    {
        public long Id { get; set; }
        public long InvestmentType { get; set; }
        public long CompanyId { get; set; }
        public decimal Amount { get; set; }
        public int Term { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime MatureDate { get; set; }
        public long ClientId { get; set; }

    }
}
