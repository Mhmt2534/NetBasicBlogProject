using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Serivces
{
    public interface ICurrentUserService
    {
        Guid GetCurrentUserId();
        string GetCurrentUserName();
        bool IsAuthenticated();
    }
}
