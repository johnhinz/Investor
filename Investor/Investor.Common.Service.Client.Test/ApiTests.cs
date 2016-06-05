using Microsoft.VisualStudio.TestTools.UnitTesting;
using Investor.Common.Service.Client.Test.Stubs;
using Investor.Common.Service.Client.Api.Controllers;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Hosting;
using Newtonsoft.Json;
using Investor.Common.Shared.Pocos;
using Investor.Common.Shared.Interfaces;
using log4net;
using System.Web.Http.Results;
using Investor.Common.Shared.DataTransferObjects;

namespace Investor.Common.Service.Client.Test
{
    [TestClass]
    public class ApiTests
    {
        private ClientController _controller;

        public ApiTests()
        {
            IClientLogic logic = new LogicStub();
            ILog log = new LogStub();
            _controller = new ClientController(logic,log);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
        }

        [TestMethod]
        public void ClientController_APILayer_GetMethod_ResultOk()
        {
            // arrange
            // -- done in the constructor
            //act
            var response = _controller.Get(1);
            //////assert
            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<ClientDto>));
            var result = response as OkNegotiatedContentResult<ClientDto>;
            Assert.AreEqual("Joe", result.Content.FirstName);
            Assert.AreEqual("Smith", result.Content.LastName);
        }
        [TestMethod]
        public void ClientController_APILayer_GetMethod_ResultVoid()
        {
            // arrange
            // -- done in the constructor
            //act
            var response = _controller.Get(2);
            //////assert
            Assert.IsInstanceOfType(response, typeof(NotFoundResult));

        }
    }
}
