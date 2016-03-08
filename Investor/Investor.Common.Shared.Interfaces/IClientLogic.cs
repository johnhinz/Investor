using Investor.Common.Shared.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Interfaces
{
    public interface IClientLogic
    {
        ClientPoco Read(long id);
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
