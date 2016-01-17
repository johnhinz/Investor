﻿using Investor.Common.Service.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investor.Common.Service.Client.Poco;

namespace Investor.Common.Service.Client.Test.Stubs
{
    class LogicStub : IClientLogic
    {
        public ClientPoco Read(long id)
        {
            return new ClientPoco() { FirstName = "Joe", LastName = "Smith" };
        }
        public void Create(ClientPoco client)
        {
            throw new NotImplementedException();
        }
    }
}
