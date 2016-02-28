using Investor.Common.Shared.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Investor.Common.Service.Company.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        [Route("{companyId}")]
        public HttpResponseMessage Get(long companyId)
        {
            var company = _logic.Read(companyId);
            if (company == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, company);
          
        }


    }
}