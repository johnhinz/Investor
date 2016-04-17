using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investor.Common.Shared.Interfaces
{
    public interface IAuthenticationRepository
    {
        bool Read(string user, string pass);
        bool Create(string user, string pass);
        bool Update(string user, string pass);
        bool Delete(string user, string pass);
        bool Verify(string user, string pass);
    }
}
