using Investor.Common.Shared.Interfaces;
using Investor.Common.Shared.Pocos;
using System.Collections.Generic;
using AutoMapper;
using Investor.Common.Shared.DataTransferObjects;

namespace Investor.Common.Service.Client.Logic
{
    public class ClientLogic : IClientLogic
    {
        private readonly IClientRepository _repository;
        

        public ClientLogic(IClientRepository repository)
        {
            _repository = repository;

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ClientAddressPoco, ClientAddressDto>();
                cfg.CreateMap<ClientPoco, ClientDto>();
            });
        }

        public void Create(ClientPoco client)
        {
            _repository.Create(client);
        }

        public ClientDto Read(long id)
        {
            var clientPoco = _repository.Read(id);
            if (clientPoco != null)
            {
                ClientDto dto = Mapper.Map<ClientDto>(clientPoco);
                return dto;
            }
            else
            {
                return null;
            }

        }

        public IEnumerable<ClientPoco> ReadLastName(string lastname)
        {
            return _repository.ReadLastName(lastname);

        }
        public IEnumerable<ClientPoco> ReadFirstName(string firstname)
        {
            return _repository.ReadFirstName(firstname);
        }

        public IEnumerable<ClientAddressPoco> ReadAddresses(long id)
        {
            return _repository.ReadAddresses(id);
        }
        public IEnumerable <ClientPhoneNumberPoco > ReadPhoneNumbers(long id)
        {
            return _repository.ReadPhoneNumbers(id);

        }
        public void DeleteClient(long id)
        {
            _repository.DeleteClient(id);
        }
        public void UpdateClient(ClientPoco client)
        {
            _repository.UpdateClient (client);
        }

        public void CreateAddress(long id, ClientAddressPoco address)
        {
            _repository.CreateAddress(id, address);
        }

        public void CreatePhoneNumber(long id,ClientPhoneNumberPoco phonenumber)
        {
            _repository.CreatePhoneNumber(id, phonenumber);

        }

        public void DeleteAddress(long clientId, long addressId)
        {
            _repository.DeleteAddress(clientId, addressId);

        }
        public void DeletePhoneNumber(long clientId,long phonenumberId)
        {
            _repository.DeletePhoneNumber(clientId, phonenumberId);
        }

        public void UpdateAddress(long clientId, ClientAddressPoco address)
        {
            _repository.UpdateAddress(clientId, address);

        }

        public void UpdatePhoneNumber(long clientId, ClientPhoneNumberPoco phonenumber)
        {
            _repository.UpdatePhoneNumber(clientId, phonenumber);

        }
    }

}
