using System;
using System.Collections.Generic;
using Investor.Common.Shared.Pocos;
using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.DataTransferObjects;

namespace Investor.Common.Service.Client.Test.Stubs
{
    class LogicStub : IClientLogic
    {
        public ClientDto Read(long id)
        {
            return new ClientDto() { FirstName = "Joe", LastName = "Smith" };
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

        

        public IEnumerable<ClientAddressPoco> ReadAddresses(long id)
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

        public void CreateAddress(long id, ClientAddressPoco address)
        {
            throw new NotImplementedException();
        }

        public void DeleteAddress(long clientId, long addressId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddress(long clientId, ClientAddressPoco address)
        {
            throw new NotImplementedException();
        }
    }
}
