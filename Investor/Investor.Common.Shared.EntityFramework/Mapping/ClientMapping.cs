using Investor.Common.Shared.Pocos;
using System.Data.Entity.ModelConfiguration;

namespace Investor.Common.Shared.EntityFramework.Mapping
{
    public class ClientMapping : EntityTypeConfiguration<ClientPoco>
    {
        public ClientMapping()
        {
            ToTable("Client");
            HasKey(c => c.Id);
        }
    }
}
