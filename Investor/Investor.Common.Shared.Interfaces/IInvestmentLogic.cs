﻿using Investor.Common.Shared.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Interfaces
{
    public interface IInvestmentLogic
    {
        InvestmentPoco Read(long id);
        void Create(InvestmentPoco investment);
        void Delete(long id);
        bool Update(long id, InvestmentPoco investment);
        
        
    }
}
