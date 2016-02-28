using Investor.Common.Service.Investment.Interface;
using Investor.Common.Service.Investment.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

        

        [HttpPost]
        [Route("createInvestment")]
        public HttpResponseMessage CreateInvestment([FromBody] InvestmentPoco investment)
        {
            _logic.Create(investment);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

      

        [HttpDelete]
        [Route("{ID}")]
        public HttpResponseMessage DeleteInvestment(long ID)
        {
            _logic.Delete(ID);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

      
    }
}
