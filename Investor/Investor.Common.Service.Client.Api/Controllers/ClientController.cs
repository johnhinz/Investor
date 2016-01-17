using Investor.Common.Service.Address.Poco;
using Investor.Common.Service.Client.Interface;
using Investor.Common.Service.Client.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Investor.Common.Service.Client.Api.Controllers
{
    [RoutePrefix ("api.invest.com/clients")]
    public class ClientController : ApiController
    {
        private IClientLogic _logic;

        public ClientController(IClientLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route ("{clientId}")]
        public HttpResponseMessage Get(long clientId)
        {
            var client = _logic.Get(clientId);
            return Request.CreateResponse(HttpStatusCode.OK, client);
        }

        [HttpGet]
        [Route ("{clientId}/addresses")]
        public HttpResponseMessage GetAddresses(long clientId)
        {
            throw new NotImplementedException();
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
        public HttpResponseMessage CreateClient([FromBody] ClientPoco client)
        {
            throw new NotImplementedException();
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
