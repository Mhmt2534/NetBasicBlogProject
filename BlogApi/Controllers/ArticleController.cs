using Application.DTOs.Article;
using Application.Interfaces.Serivces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [Authorize]
        [HttpPost("add-article")]
        public async Task<ArticleResponseDto> AddArticle([FromBody] ArticleRequestDto articleRequestDto)
        {
            return await _articleService.AddAsync(articleRequestDto);
        }

    }
}
