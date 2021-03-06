﻿using System;
using System.Collections.Generic;

namespace Investor.Common.Shared.Pocos
{
    public class InvestmentPoco
    {
        public long Id { get; set; }
        public long InvestmentType { get; set; }
        public long CompanyId { get; set; }
        public decimal Amount { get; set; }
        public int Term { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime MatureDate { get; set; }
        public long ClientId { get; set; } 
        public virtual ICollection<ClientPoco> Clients { get; set; }
    }
}
