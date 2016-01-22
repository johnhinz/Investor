using Investor.Common.Service.Investment.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Service.Investment.Interface
{
    public interface IInvestmentRepository
    {
        InvestmentPoco Read(long id);
        void Create(InvestmentPoco investment);
    }
}
