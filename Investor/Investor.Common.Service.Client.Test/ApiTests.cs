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

namespace Investor.Common.Service.Client.Test
{
    [TestClass]
    public class ApiTests
    {
        private ClientController _controller;

        public ApiTests()
        {
            IClientLogic logic = new LogicStub();
            _controller = new ClientController(logic,null);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
        }

        [TestMethod]
        public void Client_API_Get()
        {
            // arrange
            // -- done in the constructor
            //act
            //var response = _controller.Get(1);
            //var client = JsonConvert.DeserializeObject<ClientPoco>(response.ExecuteAsync.Content.ReadAsStringAsync().Result);
            ////assert
            //Assert.AreEqual("Joe", client.FirstName);
            //Assert.AreEqual("Smith", client.LastName);
        }
    }
}
