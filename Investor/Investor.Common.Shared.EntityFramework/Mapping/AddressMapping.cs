using Investor.Common.Shared.Pocos;
using System.Data.Entity.ModelConfiguration;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    class AddressMapping : EntityTypeConfiguration<AddressPoco>
    {
        public AddressMapping()
        {
            ToTable("Address");
            //HasKey(a => a.Address_Id);
        }
    }
}
