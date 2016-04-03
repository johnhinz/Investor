using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{
    public class ClientPoco
    {
        public long Id { get; set; }
        //public long AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string SocialIns { get; set; }
        public virtual ICollection<ClientAddressPoco> Addresses { get; set; }
        public virtual ICollection <ClientPhoneNumberPoco > PhoneNumbers { get; set; }
        public virtual ICollection<InvestmentPoco> Investments { get; set; }     
    }
}
