﻿using System.Collections.Generic;
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


        public IEnumerable<ClientPoco> ReadFirstName(string firstname)
        {
            return _db.Clients.Where(c => c.FirstName.Contains(firstname)).ToList();
        }

        public IEnumerable<AddressPoco> ReadAddresses(long id)
        {
            return _db.Addresses.Where(a => a.Clients.Select(c => c.Id).Contains(id)).ToList();  
        }

        public void DeleteClient(long id)
        {
            ClientPoco c = _db.Clients.Find(id);
            _db.Clients.Remove(c);
            _db.SaveChanges();
        }
        public void UpdateClient(ClientPoco client)
        {
            ClientPoco c = _db.Clients.Single(cu => cu.Id == client.Id);
            c.FirstName = client.FirstName;
            c.LastName = client.LastName;
            c.DoB = client.DoB;
            c.SocialIns = client.SocialIns;
            _db.SaveChanges();
        }

    }
}
