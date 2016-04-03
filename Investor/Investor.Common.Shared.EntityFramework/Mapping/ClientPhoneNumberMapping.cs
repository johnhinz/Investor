using Investor.Common.Shared.Pocos;
using System;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    class ClientPhoneNumberMapping:EntityTypeConfiguration <ClientPhoneNumberPoco >

    {
        public ClientPhoneNumberMapping ()
        {
            ToTable("ClientPhoneNumber");
            HasKey(c => c.PhoneNumberId);
            HasMany(p => p.Clients);

        }
    }
}
