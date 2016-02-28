using Investor.Common.Shared.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Interfaces
{
    public interface IClientRepository
    {
        ClientPoco Read(long id);
        void Create(ClientPoco client);

        IEnumerable<ClientPoco> ReadLastName(string searchString);

        ClientPoco ReadFirstName(string firstname);

        AddressPoco ReadAddresses(long id);
    }
}
