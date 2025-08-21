using Application.DTOs.Article;
using Application.Interfaces.Repositories;
using Application.Interfaces.Serivces;
using Domain.Entities;
using Domain.Utilities;
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
        private readonly ICurrentUserService _currentUserService;
        public LikeService(ILikeRepository likeRepository,ICurrentUserService currentUserService)
        {
            _likeRepository = likeRepository;
            _currentUserService = currentUserService;
        }

        public async Task<SuccessResult> AddAsync(Like like)
        {
            Guid currentUser = _currentUserService.GetCurrentUserId(); //mevcut kullanıcıyı çekiyoruz.

            bool isExist = await _likeRepository.likeIsExist(like.ArticleId,currentUser);


            //Eğer daha önce like yoksa
            if (!isExist) {
                await _likeRepository.AddAsync(like);
                return new SuccessResult("Like atıldı");
            }

            var updatedLike = await _likeRepository.getLikeByIds(like.ArticleId, currentUser);

            //eğer like varsa ama geri alınırsa veya alınmışsa
            await _likeRepository.reverseLike(updatedLike); //Tracking mekanizmasına bak. Burda yukarıkdai updatedLike da değişiyor
            return new SuccessResult(
                updatedLike.IsDelete ?
                 "Like geri çekildi." :
                 "Like atıldı."
                );
        }

        public async Task<int> getLikeCount(Guid articleId)
        {
            return await _likeRepository.getLikeCount(articleId);
        }



    }
}
