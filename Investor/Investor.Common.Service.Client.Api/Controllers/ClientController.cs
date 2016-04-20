using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using log4net;
using Investor.Common.Shared.Authentication;

namespace Investor.Common.Service.Client.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix ("api.invest.com/clients")]
    [BasicAuthenticationFilter]
    public class ClientController : ApiController
    {
        private readonly ILog _log;
        private readonly IClientLogic _logic;

        public ClientController(IClientLogic logic, ILog log)
        {
            _logic = logic;
            _log = log;
        }

        [HttpGet]
        [Route("{clientId}")]
        public IHttpActionResult Get(long clientId)
        {
            _log.Debug("Getting Client!");
            _log.DebugFormat("Method: Get, Accept: {0}", Request.Headers.Accept.ToString());
            var client = _logic.Read(clientId);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(client);
            }
        }

        [HttpGet]
        [Route ("{clientId}/addresses")]
        public HttpResponseMessage GetAddresses(long clientId)
        {
            var addresses = _logic.ReadAddresses(clientId);
            return Request.CreateResponse(HttpStatusCode.OK, addresses);
        }

        [HttpGet]
        [Route("{clientId}/phonenumbers")]
        public HttpResponseMessage GetPhoneNumbers(long clientId)
        {
            var phonenumbers = _logic.ReadPhoneNumbers(clientId);
            return Request.CreateResponse(HttpStatusCode.OK, phonenumbers);
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
        public HttpResponseMessage UpdateAddress(long clientId, [FromBody] ClientAddressPoco address)
        {
            _logic.UpdateAddress(clientId, address);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut ]
        [Route ("{cliendId}/phonenumbers/{phonenumberid}")]
        public HttpResponseMessage UpdatePhoneNumber(long clientId, [FromBody ] ClientPhoneNumberPoco phonenumber)
        {
            _logic.UpdatePhoneNumber(clientId, phonenumber);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpPost]
        [Route ("create")]
        public HttpResponseMessage CreateClient([FromBody] ClientPoco client)
        {
            _logic.Create(client);
            _log.Debug("Creating new client.");
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route ("{clientId}/addresses")]
        public HttpResponseMessage CreateAddress(long clientId, [FromBody] ClientAddressPoco address)
        {
            _logic.CreateAddress(clientId, address);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpPost ]
        [Route ("{clientId}/phonenumbers")]
        public HttpResponseMessage CreatePhoneNumber(long clientId,[FromBody ] ClientPhoneNumberPoco phonenumber)
        {
            _logic.CreatePhoneNumber(clientId ,phonenumber );
            return Request.CreateResponse(HttpStatusCode.OK );
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
        [HttpDelete ]
        [Route ("{clientId}/phonenumber/{phonenumberId}")]
        public HttpResponseMessage DeletePhoneNumber(long clientId, long phonenumberId)
        {
            _logic.DeletePhoneNumber(clientId, phonenumberId);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

    }
}
