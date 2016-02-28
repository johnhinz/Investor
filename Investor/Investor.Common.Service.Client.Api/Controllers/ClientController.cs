using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;



namespace Investor.Common.Service.Client.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix ("api.invest.com/clients")]
    public class ClientController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IClientLogic _logic;

        public ClientController(IClientLogic logic)
        {
            _logic = logic;
          
        }

        [HttpGet]
        [Route ("{clientId}")]

        public HttpResponseMessage Get(long clientId)
        {
            var client = _logic.Read(clientId);
            log.Debug("Getting Client!");
            return Request.CreateResponse(HttpStatusCode.OK, client);
          
        }

        [HttpGet]
        [Route ("{clientId}/addresses")]
        public HttpResponseMessage GetAddresses(long clientId)
        {
            var client = _logic.ReadAddresses(clientId);
            return Request.CreateResponse(HttpStatusCode.OK, client);
        }

        [HttpGet]
        [Route("LastName/{LastName}")]
        public HttpResponseMessage GetLastName(string lastname)
        {
            var client = _logic.ReadLastName(lastname);
            return Request.CreateResponse(HttpStatusCode.OK, client);
        }

        [HttpGet]
        [Route("FirstName/{FirstName}")]
        public HttpResponseMessage GetFirstName(string firstname)
        {
            var client = _logic.ReadFirstName(firstname);
            return Request.CreateResponse(HttpStatusCode.OK, client);

        }

        [HttpPut]
        public HttpResponseMessage UpdateClient([FromBody] ClientPoco client)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route ("{clientId}/address/{addressId}")]
        public HttpResponseMessage UpdateAddress(long clientId, [FromBody] AddressPoco address)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route ("create")]
        public HttpResponseMessage CreateClient([FromBody] ClientPoco client)
        {
            _logic.Create(client);
            log.Debug("Creating new client.");
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route ("{clientId}/addresses")]
        public HttpResponseMessage CreateAddress(long clientId, [FromBody] AddressPoco address)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route ("api.invest.com/client/{clientId}")]
        public HttpResponseMessage DeleteClient(long clientId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route ("{clientId}/address/{addressId}")]
        public HttpResponseMessage DeleteAddress(long clientId, long addressId)
        {
            throw new NotImplementedException();
        }
    }
}
