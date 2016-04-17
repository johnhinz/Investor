using Investor.Common.Shared.DataTransferObjects;
using Investor.Common.Shared.Pocos;

using System.Collections.Generic;


namespace Investor.Common.Shared.Interfaces
{
    public interface IClientLogic
    {
        ClientDto Read(long id);
        void Create(ClientPoco client);

        IEnumerable<ClientPoco> ReadLastName(string lastname);

        IEnumerable<ClientPoco> ReadFirstName(string firstname);

        IEnumerable<ClientAddressPoco> ReadAddresses(long id);

        void DeleteClient(long id);
        void UpdateClient(ClientPoco client);
        void DeleteAddress(long clientId, long addressId);
        void CreateAddress(long id, ClientAddressPoco address);
        void UpdateAddress(long clientId, ClientAddressPoco address);
    }
}
