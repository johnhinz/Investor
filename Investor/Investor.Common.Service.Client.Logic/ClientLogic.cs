using Investor.Common.Service.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Investor.Common.Service.Client.Poco;

namespace Investor.Common.Service.Client.Logic
{
    public class ClientLogic : IClientLogic
    {
        private IClientRepository _repository;

        public ClientLogic(IClientRepository repository)
        {
            _repository = repository;
        }

        public ClientPoco Read(long id)
        {
            return _repository.Read(id);
        }
    }
}
