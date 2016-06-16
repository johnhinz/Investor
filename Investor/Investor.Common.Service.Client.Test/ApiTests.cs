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
using System.Collections.Generic;

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
        [TestMethod]
        public void ClientController_APILayer_GetOneAddressMethod_ResultOk()
        {
            // arrange
            // -- done in the constructor
            //act
            var response = _controller.GetOneAddress(1,1);
          //assert
           
             List<ClientAddressPoco> address = JsonConvert.DeserializeObject<List<ClientAddressPoco>>(
             response.Content.ReadAsStringAsync().Result);

            foreach (ClientAddressPoco a in address)
            {
                Assert.AreEqual("ABC St", a.Street);
                Assert.AreEqual("Toronto", a.City);

            }
        }
        [TestMethod]
        public void ClientController_APILayer_GetOneAddressMethod_ResultVoid()
        {
            // arrange
            // -- done in the constructor
            //act
            var response = _controller.GetOneAddress(2, 2);
            //////assert
            List<ClientAddressPoco> address = JsonConvert.DeserializeObject<List<ClientAddressPoco>>(
            response.Content.ReadAsStringAsync().Result);
            foreach (ClientAddressPoco a in address)
            {
                Assert.IsNull(a);
            }

        }

        [TestMethod]
        public void ClientController_APILayer_GetAddressesMethod_ResultOk()
        {
            // arrange
            // -- done in the constructor
            //act
            var response = _controller.GetAddresses(1);
            //assert
            //ClientAddressPoco client = response.Content.ReadAsAsync<ClientAddressPoco>().Result;
            List<ClientAddressDto> addresses = JsonConvert.DeserializeObject<List<ClientAddressDto>>(
              response.Content.ReadAsStringAsync().Result);

            foreach (ClientAddressDto a in addresses)
            {
                Assert.AreEqual("ABC St", a.Street);
                Assert.AreEqual("Toronto", a.City);

            }

        }

        [TestMethod]
        public void ClientController_APILayer_GetOneAddressesMethod_ResultVoid()
        {
            // arrange
            // -- done in the constructor
            //act
            var response = _controller.GetAddresses(2);
            //////assert
            List<ClientAddressDto> addresses = JsonConvert.DeserializeObject<List<ClientAddressDto>>(
            response.Content.ReadAsStringAsync().Result);
            foreach (ClientAddressDto a in addresses)
            {
                Assert.IsNull(a);
            }

        }
    }
}
