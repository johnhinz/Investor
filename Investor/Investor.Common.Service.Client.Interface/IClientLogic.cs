﻿using Investor.Common.Service.Client.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Service.Client.Interface
{
    public interface IClientLogic
    {
        ClientPoco Read(long id);
        void Create(ClientPoco client);

        ClientPoco ReadLastName(string lastname);

        ClientPoco ReadFirstName(string firstname);

        AddressPoco ReadAddresses(long id);
    }
}
