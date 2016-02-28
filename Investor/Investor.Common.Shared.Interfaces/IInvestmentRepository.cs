using Investor.Common.Shared.Pocos;

namespace Investor.Common.Shared.Interfaces
{
    public interface IInvestmentRepository
    {
        InvestmentPoco Read(long id);
        void Create(InvestmentPoco investment);
        void Delete(long id);
    }
}
