using Application.DTOs.Article;
using Domain.Entities;
using Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Serivces
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleResponseDto>> GetAllAsync();
        Task<ArticleResponseDto?> GetByIdAsync(Guid id);
        public Task<IEnumerable<ArticleResponseDto>> GetAllForUserAsync();
        Task<ArticleResponseDto> AddAsync(ArticleRequestDto article);
        Task<DataResult<ArticleResponseDto>> UpdateAsync(ArticleRequestDto articleRequest);
        Task<DataResult<ArticleResponseDto>> DeleteAsync(Guid id);
    }
}
