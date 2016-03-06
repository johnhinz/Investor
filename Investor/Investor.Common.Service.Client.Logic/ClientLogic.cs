using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;
using System.Collections.Generic;
using System;

namespace Investor.Common.Service.Client.Logic
{
    public class ClientLogic : IClientLogic
    {
        private IClientRepository _repository;

        public ClientLogic(IClientRepository repository)
        {
            _repository = repository;
        }

        public void Create(ClientPoco client)
        {
            _repository.Create(client);
        }

        public ClientPoco Read(long id)
        {
            return _repository.Read(id);
        }

        public IEnumerable<ClientPoco> ReadLastName(string lastname)
        {
            return _repository.ReadLastName(lastname);

        }
        public IEnumerable<ClientPoco> ReadFirstName(string firstname)
        {
            return _repository.ReadFirstName(firstname);
        }

        public IEnumerable<AddressPoco> ReadAddresses(long id)
        {
            return _repository.ReadAddresses(id);
        }
        public void DeleteClient(long id)
        {
            _repository.DeleteClient(id);
        }
        public void UpdateClient(ClientPoco client)
        {
            _repository.UpdateClient (client);
        }

        public void CreateAddress(long id, AddressPoco address)
        {
            _repository.CreateAddress(id, address);
        }

        public void DeleteAddress(long clientId, long addressId)
        {
            _repository.DeleteAddress(clientId, addressId);

        }

        public void UpdateAddress(long clientId, AddressPoco address)
        {
            _repository.UpdateAddress(clientId, address);

        }
    }

}
