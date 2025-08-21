using Application.DTOs.Article;
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
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        private readonly BlogDbContext _dbContext;
        public ArticleRepository(BlogDbContext dbContext) : base(dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ArticleResponseDto>> GetArticlesByLikeCount() 
        { 
            var articles = await _dbContext.Articles.Where(a=>a.IsDelete==false).Select(
                a=>new ArticleResponseDto
                {
                    Id=a.Id,
                    Header = a.Header,
                    Content = a.Content,
                    LikeCount = a.Likes.Count()
                }).ToListAsync();

            return articles;
        }

        public async Task<IEnumerable<ArticleResponseDto>> GetArticlesForUsers(Guid authorId)
        {
            var articles = await _dbContext.Articles.Where(a=>a.AuthorId == authorId && a.IsDelete == false).Select(
                a => new ArticleResponseDto
                {
                    Id = a.Id,
                    Header = a.Header,
                    Content = a.Content,
                    LikeCount = a.Likes.Count()
                }).ToListAsync();


            return articles;
        }


    }
}
