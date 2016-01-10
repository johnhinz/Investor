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
    [RoutePrefix ("api.invest.com/client")]
    public class ClientController : ApiController
    {
        private IClientLogic _logic;

        public ClientController(IClientLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route ("{id}")]
        public ClientPoco Get()
        {
            return _logic.Get(1);
        }
    }
}
