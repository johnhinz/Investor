using Investor.Common.Shared.Pocos;
using System.Data.Entity.ModelConfiguration;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    class ClientAddressMapping : EntityTypeConfiguration<ClientAddressPoco>
    {
        public ClientAddressMapping()
        {
            ToTable("ClientAddress");
            HasKey(c => c.AddressId);

            HasMany(a => a.Clients);
        }

    }
}
