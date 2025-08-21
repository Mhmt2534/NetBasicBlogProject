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

        public async Task<DataResult<ArticleResponseDto>> DeleteAsync(Guid id)
        {
            var currentUserId = _currentUserService.GetCurrentUserId();

            Article article = await _articleRepository.GetByIdAsync(id);

            if (article is null)
                return new ErrorDataResult<ArticleResponseDto>("Makale bulunamadı");

            if (article.AuthorId != currentUserId)
                return new ErrorDataResult<ArticleResponseDto>("Böyle bir yetkiniz yok");

            Article newArticle = await _articleRepository.DeleteAsync(id);
            ArticleResponseDto articleResponseDto = new ArticleResponseDto()
            {
                Id = newArticle.Id,
                Content = newArticle.Content,
                Header = newArticle.Header
            };


            return new SuccessDataResult<ArticleResponseDto>(articleResponseDto, "Makale silindi");
        }

        public async Task<IEnumerable<ArticleResponseDto>> GetAllAsync()
        {
            IEnumerable<ArticleResponseDto> articleResponseDto;
            articleResponseDto= await _articleRepository.GetArticlesByLikeCount();
            return articleResponseDto;
        }

        public async Task<IEnumerable<ArticleResponseDto>> GetAllForUserAsync()
        {
            IEnumerable<ArticleResponseDto> articleResponseDto;
            Guid authorId = _currentUserService.GetCurrentUserId();
            articleResponseDto = await _articleRepository.GetArticlesForUsers(authorId);
            return articleResponseDto;
        }


        public Task<ArticleResponseDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResult<ArticleResponseDto>> UpdateAsync(ArticleRequestDto articleRequest)
        {
            var currentUserId = _currentUserService.GetCurrentUserId();

            Article article = await _articleRepository.GetByIdAsync(articleRequest.Id);

            if (article is null) 
                    return new ErrorDataResult<ArticleResponseDto>("Makale bulunamadı");

            if (article.AuthorId != currentUserId)
                return new ErrorDataResult<ArticleResponseDto>("Böyle bir yetkiniz yok");

            article.Header=articleRequest.Header;
            article.Content=articleRequest.Content;

            Article newArticle = await _articleRepository.UpdateAsync(article);
            ArticleResponseDto articleResponseDto = new ArticleResponseDto()
            {
                Id = newArticle.Id,
                Content = newArticle.Content,
                Header = newArticle.Header
            };


            return new SuccessDataResult<ArticleResponseDto>(articleResponseDto,"Makale güncellendi");
        }
    }
}
