using Investor.Common.Service.Client.Poco;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
