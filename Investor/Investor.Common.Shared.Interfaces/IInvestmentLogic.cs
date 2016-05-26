using Investor.Common.Shared.DataTransferObjects;
using Investor.Common.Shared.Pocos;
using System;
using System.Collections.Generic;

namespace Investor.Common.Shared.Interfaces
{
    public interface IInvestmentLogic
    {
        InvestmentDto Read(long id);
        void Create(InvestmentPoco investment);
        void Delete(long id);
        bool Update(long id, InvestmentPoco investment);
        IEnumerable<InvestmentClientPoco> ReadClient(long id);
        void CreateInvestmentType(InvestmentTypePoco investmenttype);
        InvestmentTypePoco ReadInvestmentType(long id);
        void DeleteInvestmentType(long id);
        bool UpdateInvestmentType(long id, InvestmentTypePoco investmenttype);
        IEnumerable<InvestmentPoco> ReadByMatureDate(DateTime maturedate, int skip, int take);
        
    }
}
