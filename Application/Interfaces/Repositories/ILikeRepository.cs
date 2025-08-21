using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ILikeRepository 
    {
        Task<Like> AddAsync(Like like);
        Task<int> getLikeCount(Guid articleId);
        public  Task<bool> likeIsExist(Guid articleId, Guid UserId);
        public  Task<Like> getLikeByIds(Guid articleId, Guid UserId);
        public Task reverseLike(Like like);

    }
}
