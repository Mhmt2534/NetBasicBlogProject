using Application.DTOs.Article;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IArticleRepository: IGenericRepository<Article>
    {
        public  Task<IEnumerable<ArticleResponseDto>> GetArticlesByLikeCount();
        public  Task<IEnumerable<ArticleResponseDto>> GetArticlesForUsers(Guid authorId);
    }
}
