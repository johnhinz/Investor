﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Investor.Common.Service.Client.Interface;
using Investor.Common.Service.Client.Test.Stubs;
using Investor.Common.Service.Client.Api.Controllers;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Hosting;
using Investor.Common.Service.Client.Poco;
using Newtonsoft.Json;

namespace Investor.Common.Service.Client.Test
{
    [TestClass]
    public class ApiTests
    {
        private ClientController _controller;

        public ApiTests()
        {
            IClientLogic logic = new LogicStub();
            _controller = new ClientController(logic);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
        }

        [TestMethod]
        public void Client_API_Get()
        {
            // arrange
            // -- done in the constructor
            //act
            var response = _controller.Get(1);
            var client = JsonConvert.DeserializeObject<ClientPoco>(response.Content.ReadAsStringAsync().Result);
            //assert
            Assert.AreEqual("Joe", client.FirstName);
            Assert.AreEqual("Smith", client.LastName);
        }
    }
}
