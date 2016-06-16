using System;
using System.Collections.Generic;
using Investor.Common.Shared.Pocos;
using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.DataTransferObjects;

namespace Investor.Common.Service.Client.Test.Stubs
{
   public class LogicStub : IClientLogic
    {
        public ClientDto Read(long id)
        {
            if (id == 1)
            {
                return new ClientDto() { FirstName = "Joe", LastName = "Smith" };
            }
            else
            {
                return null;
            }
        }
        public void Create(ClientPoco client)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<ClientPoco> ReadLastName(string lastname)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientPoco> ReadFirstName(string firstname)
        {
            throw new NotImplementedException();
        }

        

        public IEnumerable<ClientAddressDto> ReadAddresses(long id)
        {
           if(id == 1)
            {
               yield return new ClientAddressDto() { Street = "ABC St", City = "Toronto" };
            }
            else
            {
                yield return null;
            }

        }

        public IEnumerable<ClientAddressPoco> ReadOneAddress(long clientId, long addressId)
        {
            if (clientId == 1 && addressId == 1)
            {
               yield return new ClientAddressPoco() { Street = "ABC St", City ="Toronto"};
            }
            else
            {
               yield return null;
            }


        }
        public IEnumerable <ClientPhoneNumberPoco > ReadOnePhoneNumber(long clientId, long phonenumberId)
        {
            throw new NotImplementedException();
        }
        public void DeleteClient(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(ClientPoco client)
        {
            throw new NotImplementedException();
        }

        public void CreateAddress(long id, ClientAddressPoco address)
        {
            throw new NotImplementedException();
        }

        public void DeleteAddress(long clientId, long addressId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddress(long clientId, long addressId, ClientAddressPoco address)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientPhoneNumberPoco> ReadPhoneNumbers(long id)
        {
            throw new NotImplementedException();
        }

        public void DeletePhoneNumber(long clientId, long phonenumberId)
        {
            throw new NotImplementedException();
        }

        public void CreatePhoneNumber(long id, ClientPhoneNumberPoco phonenumber)
        {
            throw new NotImplementedException();
        }

        public void UpdatePhoneNumber(long clientId, long PhoneNumberId,ClientPhoneNumberPoco phonenumber)
        {
            throw new NotImplementedException();
        }
    }
}
