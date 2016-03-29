using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Pocos
{

    public enum PhoneNumberEnum
    {
        Cell,
        Work,
        Home,
        Fax
    }
    public class ClientPhoneNumberPoco
    {
        public long Id { get; set; }
        public string PhoneNo { get; set; }
        public PhoneNumberEnum PhoneType { get; set; }
        public virtual ICollection <ClientPoco > Clients { get; set; }

    }
}
