using Application.DTOs.Article;
using Domain.Entities;
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
        Task<ArticleResponseDto> AddAsync(ArticleRequestDto article);
        Task<ArticleResponseDto> UpdateAsync(ArticleRequestDto article);
        Task<ArticleResponseDto> DeleteAsync(Guid id);
    }
}
