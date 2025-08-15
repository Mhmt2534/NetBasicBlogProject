using Application.DTOs.Article;
using Application.Interfaces.Repositories;
using Application.Interfaces.Serivces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILikeService _likeService;
        public ArticleService(IArticleRepository articleRepository,ICurrentUserService currentUserService, ILikeService likeService)
        {
            _articleRepository = articleRepository;
            _currentUserService = currentUserService;
            _likeService = likeService;
        }

        public async Task<ArticleResponseDto> AddAsync(ArticleRequestDto article)
        {
            Article newArticle = new Article()
            {
                Header= article.Header,
                Content= article.Content,
                AuthorId=_currentUserService.GetCurrentUserId(),
            };

            await _articleRepository.AddAsync(newArticle);

            ArticleResponseDto articleResponse = new ArticleResponseDto
            {
                Header = article.Header,
                Content = article.Content,
                Id = newArticle.Id,
                LikeCount = 0
            };

            return articleResponse;
        }

        public Task<ArticleResponseDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArticleResponseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ArticleResponseDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleResponseDto> UpdateAsync(ArticleRequestDto article)
        {
            throw new NotImplementedException();
        }
    }
}
