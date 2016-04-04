using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{
    public enum InvestmentTypeEnum
    {
        GIC,
        RSP,
        RIF,
        TFSA,
        ESP,
        DSP
    }
    [DataContract]
    public class InvestmentPoco
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public InvestmentTypeEnum InvestmentType { get; set; }
        [DataMember]
        public long CompanyId { get; set; }
        public virtual ICollection<ClientPoco> Clients { get; set; }
    }
}
