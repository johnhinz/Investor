using Investor.Common.Service.Client.Interface;
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

        public ClientPoco ReadLastName(string lastname)
        {
            throw new NotImplementedException();
        }

        public ClientPoco ReadFirstName(string firstname)
        {
            throw new NotImplementedException();
        }

        public ClientPoco ReadAddresses(long id)
        {
            throw new NotImplementedException();
        }

        AddressPoco IClientLogic.ReadAddresses(long id)
        {
            throw new NotImplementedException();
        }
    }
}
