using Investor.Common.Service.Company.Interface;
using Investor.Common.Service.Company.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Investor.Common.Service.Company.Api.Controllers
{
    [RoutePrefix("api.invest.com/company")]
    public class CompanyController : ApiController
    {
        // GET: Company
        private ICompanyLogic _logic;

        public CompanyController(ICompanyLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("{id}")]
        public CompanyPoco Get(long id)
        {
            return _logic.Get(id);
        }
    }
}