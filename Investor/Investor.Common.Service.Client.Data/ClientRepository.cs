using Investor.Common.Service.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investor.Common.Service.Client.Poco;

namespace Investor.Common.Service.Client.Data
{
    public class ClientRepository : IClientRepository
    {
        public ClientPoco GetClient(long id)
        {
            return new ClientPoco() { FirstName = "Joe", LastName = "Smith" };
        }
    }
}
