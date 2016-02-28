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

        ClientPoco ReadFirstName(string firstname);

        AddressPoco ReadAddresses(long id);
    }
}
