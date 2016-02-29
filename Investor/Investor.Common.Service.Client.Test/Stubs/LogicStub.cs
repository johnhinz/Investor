using System;
using System.Collections.Generic;
using Investor.Common.Shared.Pocos;
using Investor.Common.Shared.Interfaces;

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

        public IEnumerable<ClientPoco> ReadLastName(string lastname)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientPoco> ReadFirstName(string firstname)
        {
            throw new NotImplementedException();
        }

        

        public IEnumerable<AddressPoco> ReadAddresses(long id)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(ClientPoco client)
        {
            throw new NotImplementedException();
        }
    }
}
