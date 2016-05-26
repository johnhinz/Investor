using System;
using System.Collections.Generic;
using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;
using AutoMapper;
using Investor.Common.Shared.DataTransferObjects;

namespace Investor.Common.Service.Investment.Logic
{
    public class InvestmentLogic : IInvestmentLogic
    {
        private IInvestmentRepository _repository;

        public InvestmentLogic(IInvestmentRepository repository)
        {
            _repository = repository;
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<InvestmentPoco, InvestmentDto>();
            });
        }

        public void Create(InvestmentPoco investment)
        {
            _repository.Create(investment);
        }

        public void CreateInvestmentType(InvestmentTypePoco investmenttype)
        {
            _repository.CreateInvestmentType(investmenttype);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public void DeleteInvestmentType(long id)
        {
            _repository.DeleteInvestmentType(id);
        }

        public InvestmentDto Read(long id)
        {
            var investPoco = _repository.Read(id);
            if (investPoco != null)
            {
                InvestmentDto dto = Mapper.Map<InvestmentDto>(investPoco);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<InvestmentPoco> ReadByMatureDate(DateTime maturedate, int skip, int take)
        {
            return _repository.ReadByMatureDate(maturedate, skip, take);
        }

        public IEnumerable<InvestmentClientPoco> ReadClient(long id)
        {
            return _repository.ReadClient(id);
        }

        public InvestmentTypePoco ReadInvestmentType(long id)
        {
            return _repository.ReadInvestmentType(id);
        }

        public bool Update(long id, InvestmentPoco investment)
        {
            var isupdated = _repository.Update(id, investment);
            if (isupdated)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool UpdateInvestmentType(long id, InvestmentTypePoco investmenttype)
        {
            var isupdated = _repository.UpdateInvestmentType(id, investmenttype);
            if (isupdated)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
