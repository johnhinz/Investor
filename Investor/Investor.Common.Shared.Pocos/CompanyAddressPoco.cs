using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{
    public class CompanyAddressPoco : AddressPoco
    {
        public virtual ICollection<CompanyPoco> Companies { get; set; }
    }
}
