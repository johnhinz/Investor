﻿using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;


namespace Investor.Common.Service.Investment.Api
{
    [RoutePrefix("api.invest.com/investments")]
    public class InvestmentController : ApiController
    {
        private IInvestmentLogic _logic;

        public InvestmentController(IInvestmentLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("{investmentId}")]
        public HttpResponseMessage Get(long investmentId)
        {
            var investment = _logic.Read(investmentId);
            return Request.CreateResponse(HttpStatusCode.OK, investment);
        }
        [HttpGet]
        [Route("investmentTypes/{investmentId}")]
        public HttpResponseMessage GetInvestmentType(long investmentId)
        {
            var investment = _logic.ReadInvestmentType(investmentId);
            return Request.CreateResponse(HttpStatusCode.OK, investment);
        }

        [HttpGet]
        [Route("{investmentId}/clients")]
        public HttpResponseMessage GetClients(long investmentId)
        {
            var clients = _logic.ReadClient(investmentId);
            return Request.CreateResponse(HttpStatusCode.OK, clients);
        }

        [HttpGet]
        [Route("maturing/{date}/{skip}/{take}")]
        public HttpResponseMessage GetAllMaturedate(DateTime date,int skip,int take)
        {
            var investment = _logic.ReadByMatureDate(date,skip,take);
            return Request.CreateResponse(HttpStatusCode.OK, investment);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateInvestment([FromBody] InvestmentPoco investment)
        {
            _logic.Create(investment);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

      [HttpPost]
      [Route("Type")]
      public HttpResponseMessage CreateInvestmentType([FromBody] InvestmentTypePoco investmenttype)
        {
            _logic.CreateInvestmentType(investmenttype);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{ID}")]
        public HttpResponseMessage DeleteInvestment(long ID)
        {
            _logic.Delete(ID);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("investmenttype/{id}")]
        public HttpResponseMessage DeleteInvestmenttype(long id)
        {
            _logic.DeleteInvestmentType(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("UpdateInvestment")]
        public HttpResponseMessage UpdateInvestment([FromBody]InvestmentPoco investment)
        {
            var isUpdated = _logic.Update(investment.Id, investment);
            if (isUpdated == true)
                return Request.CreateResponse(HttpStatusCode.OK, investment);
            else
                return Request.CreateResponse(HttpStatusCode.NotModified, investment);

        }

        [HttpPut]
        [Route("UpdateInvestmentType")]
        public HttpResponseMessage UpdateInvestmentType([FromBody]InvestmentTypePoco investmenttype)
        {
            var isUpdated = _logic.UpdateInvestmentType(investmenttype.Id, investmenttype);
            if (isUpdated == true)
                return Request.CreateResponse(HttpStatusCode.OK, investmenttype);
            else
                return Request.CreateResponse(HttpStatusCode.NotModified, investmenttype);

        }
    }
}
