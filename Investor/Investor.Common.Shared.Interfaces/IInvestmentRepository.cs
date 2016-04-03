using Investor.Common.Shared.Pocos;
using System.Collections.Generic;
namespace Investor.Common.Shared.Interfaces
{
    public interface IInvestmentRepository
    {
        InvestmentPoco Read(long id);
        void Create(InvestmentPoco investment);
        void Delete(long id);
        bool Update(long id, InvestmentPoco investment);
        IEnumerable<InvestmentClientPoco> ReadClient(long id);
       
    }
}
