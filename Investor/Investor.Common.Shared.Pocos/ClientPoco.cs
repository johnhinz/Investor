using System;
using System.Collections.Generic;

namespace Investor.Common.Shared.Pocos
{
    public class ClientPoco
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string SocialIns { get; set; }
        public virtual ICollection<ClientAddressPoco> Addresses { get; set; }
        public virtual ICollection <ClientPhoneNumberPoco > PhoneNumbers { get; set; }
        public virtual ICollection<InvestmentPoco> Investments { get; set; }     
    }
}
