using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class LikeRepository :  ILikeRepository
    {
        private readonly BlogDbContext _dbContext;
        public LikeRepository(BlogDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Like> AddAsync(Like like)
        {
            await _dbContext.Likes.AddAsync(like);
            await _dbContext.SaveChangesAsync();
            return like;
        }

        public async Task<int> getLikeCount(Guid articleId)
        {
            return await _dbContext.Likes.CountAsync(l =>l.ArticleId ==articleId);
        }

        public async Task<bool> likeIsExist(Guid articleId, Guid UserId)
        {
            return await _dbContext.Likes.AnyAsync(l => l.ArticleId == articleId && l.UserId == UserId);
        }

        public async Task<Like> getLikeByIds(Guid articleId, Guid UserId)
        {
            return await _dbContext.Likes.FirstOrDefaultAsync(l => l.ArticleId == articleId && l.UserId == UserId);
        }

        public async Task reverseLike(Like like)
        {
            like.UpdatedTime =  DateTime.UtcNow;
            like.IsDelete = !like.IsDelete;
            await _dbContext.SaveChangesAsync();
        }

    }
}
