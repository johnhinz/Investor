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
            var addresses = _logic.ReadAddresses(clientId);
            return Request.CreateResponse(HttpStatusCode.OK, addresses);
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
        [Route ("update")]
        public HttpResponseMessage UpdateClient([FromBody] ClientPoco client)
        {

            _logic.UpdateClient (client);
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route ("{clientId}/address/{addressId}")]
        public HttpResponseMessage UpdateAddress(long clientId, [FromBody] AddressPoco address)
        {
            _logic.UpdateAddress(clientId, address);
            return Request.CreateResponse(HttpStatusCode.OK);
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
            _logic.CreateAddress(clientId, address);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpDelete]
        [Route ("{clientId}")]
        public HttpResponseMessage DeleteClient(long clientId)
        {
            _logic.DeleteClient(clientId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route ("{clientId}/address/{addressId}")]
        public HttpResponseMessage DeleteAddress(long clientId, long addressId)
        {
            _logic.DeleteAddress(clientId, addressId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
