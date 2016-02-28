using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;
using System.Collections.Generic;

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
        public ClientPoco ReadFirstName(string firstname)
        {
            return _repository.ReadFirstName(firstname);
        }

        public AddressPoco ReadAddresses(long id)
        {
            return _repository.ReadAddresses(id);
        }
    }
}
