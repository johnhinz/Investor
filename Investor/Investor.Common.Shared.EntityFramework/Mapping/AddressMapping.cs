using Investor.Common.Service.Address.Poco;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    class AddressMapping : EntityTypeConfiguration<AddressPoco>
    {
        public AddressMapping()
        {
            ToTable("Address");
            HasKey(a => a.Id);
        }
    }
}
