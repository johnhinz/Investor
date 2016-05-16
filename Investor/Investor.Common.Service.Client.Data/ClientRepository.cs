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


        public IEnumerable<ClientPoco> ReadFirstName(string firstname)
        {
            return _db.Clients.Where(c => c.FirstName.Contains(firstname)).ToList();
        }

        public IEnumerable<ClientAddressPoco> ReadAddresses(long id)
        {
            return _db.ClientAddresses.Where(a => a.Clients.Select(c => c.Id).Contains(id)).ToList();  
        }

        public IEnumerable <ClientAddressPoco > ReadOneAddress(long clientId, long addressId)
        {
            return _db.ClientAddresses.Where(ad => ad.AddressId == addressId).Where(a => a.Clients.Select(c => c.Id).Contains(clientId)).ToList();

        }

        public IEnumerable <ClientPhoneNumberPoco > ReadOnePhoneNumber(long clientId, long phonenumberId)
        {
            return _db.ClientPhones.Where(ph => ph.PhoneNumberId == phonenumberId).Where(p => p.Clients.Select(c => c.Id).Contains(clientId)).ToList();

        }

        public IEnumerable <ClientPhoneNumberPoco > ReadPhoneNumbers(long id)
        {
            return _db.ClientPhones.Where(a => a.Clients.Select(c => c.Id).Contains(id)).ToList();

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
        public void CreateAddress(long id, ClientAddressPoco address)
        {
            ClientPoco c =  _db.Clients.Single(cust => cust.Id == id);
            c.Addresses.Add(address);
            _db.SaveChanges();
        }

        public void CreatePhoneNumber(long id, ClientPhoneNumberPoco phonenumber)
        {
            ClientPoco c = _db.Clients.Single(cust => cust.Id == id);
            c.PhoneNumbers.Add(phonenumber);
            _db.SaveChanges();

        }
        public void DeleteAddress(long clientid,long addressid)
        {
            ClientAddressPoco a = _db.ClientAddresses.Single(ad => ad.AddressId == addressid);
            ClientPoco c = _db.Clients.Single(cust => cust.Id == clientid);
            c.Addresses.Remove (a);
            _db.SaveChanges();
            
        }
        public void DeletePhoneNumber(long clientid,long phonenumberid)
        {
            ClientPhoneNumberPoco p = _db.ClientPhones.Single(ph => ph.PhoneNumberId == phonenumberid);
            ClientPoco c = _db.Clients.Single(cust => cust.Id == clientid);
            c.PhoneNumbers.Remove(p);
            _db.SaveChanges();

        }

        public void UpdateAddress(long clientId, long addressId, ClientAddressPoco address)
        {
            ClientPoco c = _db.Clients.Single(cu => cu.Id == clientId);
            ClientAddressPoco a = c.Addresses.Single(ad => ad.AddressId == addressId);
            a.Street = address.Street;
            a.Province = address.Province;
            a.City = address.City;
            a.Postal_Code = address.Postal_Code;
            _db.SaveChanges();
        }

        public void UpdatePhoneNumber(long clientId, long PhoneNumberId, ClientPhoneNumberPoco phonenumber)
        {
            ClientPoco c = _db.Clients.Single(cu => cu.Id == clientId);
            ClientPhoneNumberPoco p = c.PhoneNumbers.Single(pn => pn.PhoneNumberId == PhoneNumberId);
            p.PhoneNo = phonenumber.PhoneNo;
            p.PhoneType = phonenumber.PhoneType;
            _db.SaveChanges();

        }

    }
}
