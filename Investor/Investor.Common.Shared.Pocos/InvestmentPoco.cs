using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{
    
    [DataContract]
    public class InvestmentPoco
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long InvestmentType { get; set; }
        [DataMember]
        public long CompanyId { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public int Term { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime MatureDate { get; set; }
        [DataMember]
        public long ClientId { get; set; } 

        public virtual ICollection<ClientPoco> Clients { get; set; }
    }
}
