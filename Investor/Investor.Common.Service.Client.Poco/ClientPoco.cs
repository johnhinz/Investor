using Investor.Common.Service.Address.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Service.Client.Poco
{
    public class ClientPoco
    {
        public long Id { get; set; }
        //public long AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string SocialIns { get; set; }
        public virtual ICollection<AddressPoco> Addresses { get; set; }

        // public virtual PhoneNumberPoco PhoneNumber {get;set;}
    }
}
