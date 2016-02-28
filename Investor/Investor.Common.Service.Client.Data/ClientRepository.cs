using System.Collections.Generic;
using System.Linq;
using Investor.Common.Shared.EntityFramework;
using Investor.Common.Shared.Pocos;
using Investor.Common.Shared.Interfaces;

namespace Investor.Common.Service.Client.Data
{
    public class ClientRepository : IClientRepository
    {
        protected InvestorContext _db;
        public ClientRepository()
        {
            _db = new InvestorContext();
        }

        public void Create(ClientPoco client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
        }

        public ClientPoco Read(long id)
        {
            return _db.Clients.Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<ClientPoco> ReadLastName(string searchString)
        {
            return _db.Clients.Where(c => c.LastName.Contains(searchString)).ToList();
        }


        public ClientPoco ReadFirstName(string firstname)
        {
            return _db.Clients.Where(c => c.FirstName == firstname).FirstOrDefault();
        }

        public AddressPoco ReadAddresses(long id)
        {
            return _db.Addresses.Where(c => c.Clients.Equals(id)).FirstOrDefault();
           
        }
    }
}
