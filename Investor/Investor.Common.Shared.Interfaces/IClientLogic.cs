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

        IEnumerable<ClientAddressPoco> ReadOneAddress(long clientId, long addressId);

        IEnumerable<ClientPhoneNumberPoco> ReadPhoneNumbers(long id);


        void DeleteClient(long id);
        void UpdateClient(ClientPoco client);
        void DeleteAddress(long clientId, long addressId);
        void DeletePhoneNumber(long clientId, long phonenumberId);
        void CreateAddress(long id, ClientAddressPoco address);
        void CreatePhoneNumber(long id, ClientPhoneNumberPoco phonenumber);
        void UpdateAddress(long clientId, long addressId, ClientAddressPoco address);
        void UpdatePhoneNumber(long clientId, long PhoneNumberId,ClientPhoneNumberPoco phonenumber);

    }
}
