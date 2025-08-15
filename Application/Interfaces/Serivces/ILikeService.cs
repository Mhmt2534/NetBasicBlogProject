using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Serivces
{
    public interface ILikeService
    {
        Task<int> getLikeCount(Guid articleId);
    }
}
