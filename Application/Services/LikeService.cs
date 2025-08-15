using Application.Interfaces.Repositories;
using Application.Interfaces.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<int> getLikeCount(Guid articleId)
        {
            return await _likeRepository.getLikeCount(articleId);
        }
    }
}
