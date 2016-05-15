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
        //api.invest.com/clients/{clientId}/addresses/{addressId}

        [HttpGet]
        [Route ("{clientId}/addresses/{addressId}")]
        public HttpResponseMessage GetOneAddress(long clientId, long addressId)
        {
            var address = _logic.ReadOneAddress(clientId,addressId);
            return Request.CreateResponse(HttpStatusCode.OK, address);

        }

        //api.invest.com/clients/{clientId}/phonenumbers
        [HttpGet]
        [Route("{clientId}/phonenumbers")]
        public HttpResponseMessage GetPhoneNumbers(long clientId)
        {
            var phonenumbers = _logic.ReadPhoneNumbers(clientId);
            return Request.CreateResponse(HttpStatusCode.OK, phonenumbers);
        }

        //api.invest.com/clients/LastName/{LastName}
        [HttpGet]
        [Route("LastName/{LastName}")]
        public HttpResponseMessage GetLastName(string lastname)
        {
            var client = _logic.ReadLastName(lastname);
            if (client != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, client);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, client);
            }
        }

        //api.invest.com/clients/FirstName/{FirstName}
        [HttpGet]
        [Route("FirstName/{FirstName}")]
        public HttpResponseMessage GetFirstName(string firstname)
        {
            var client = _logic.ReadFirstName(firstname);
            return Request.CreateResponse(HttpStatusCode.OK, client);

        }

        [HttpPut]
        [Route ("")]
        public HttpResponseMessage UpdateClient([FromBody] ClientPoco client)
        {

            _logic.UpdateClient (client);
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        //api.invest.com/clients/{clientId}/addresses/{addressid}
        [HttpPut]
        [Route ("{clientId}/addresses/{addressId}")]
        public HttpResponseMessage UpdateAddress(long clientId, long addressId, [FromBody] ClientAddressPoco address)
        {
            _logic.UpdateAddress(clientId, addressId, address);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //api.invest.com/clients/{clientId}/phonenumbers/{phonenumberid}
        [HttpPut ]
        [Route ("{clientId}/phonenumbers/{phonenumberid}")]
        public HttpResponseMessage UpdatePhoneNumber(long clientId,long PhoneNumberId, [FromBody ] ClientPhoneNumberPoco phonenumber)
        {
            _logic.UpdatePhoneNumber(clientId,PhoneNumberId, phonenumber);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpPost]
        [Route ("")]
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
        [Route ("{clientId}/addresses/{addressId}")]
        public HttpResponseMessage DeleteAddress(long clientId, long addressId)
        {
            _logic.DeleteAddress(clientId, addressId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpDelete ]
        [Route ("{clientId}/phonenumbers/{phonenumberId}")]
        public HttpResponseMessage DeletePhoneNumber(long clientId, long phonenumberId)
        {
            _logic.DeletePhoneNumber(clientId, phonenumberId);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

    }
}
