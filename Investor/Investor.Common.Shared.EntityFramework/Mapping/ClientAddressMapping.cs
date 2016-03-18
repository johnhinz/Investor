using Investor.Common.Shared.Pocos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    class ClientAddressMapping : EntityTypeConfiguration<ClientAddressPoco>
    {
        public ClientAddressMapping()
        {
            ToTable("Address");
            HasKey(a => a.Id);
        }

    }
}
