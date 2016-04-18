using Investor.Common.Shared.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.DataTransferObjects
{
    public class ClientAddressDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string SocialIns { get; set; }
        ICollection<ClientAddressPoco> Addresses {get;set;}
    }
}
