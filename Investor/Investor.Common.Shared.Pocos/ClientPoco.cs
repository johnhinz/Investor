using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Investor.Common.Shared.Pocos
{
    [DataContract]
    public class ClientPoco
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public DateTime DoB { get; set; }
        [DataMember]
        public string SocialIns { get; set; }
        public virtual ICollection<ClientAddressPoco> Addresses { get; set; }
        public virtual ICollection <ClientPhoneNumberPoco > PhoneNumbers { get; set; }
        public virtual ICollection<InvestmentPoco> Investments { get; set; }     
    }
}
