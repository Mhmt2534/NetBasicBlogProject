using Application.DTOs.Article;
using Application.Interfaces.Serivces;
using Domain.Entities;
using Domain.Utilities;
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


        [Authorize]
        [HttpGet("get-all-article")]
        public async Task<IEnumerable<ArticleResponseDto>> GetAllArticle()
        {
            return await _articleService.GetAllAsync();
        }



        [Authorize]
        [HttpGet("get-all-article-for-user")]
        public async Task<IEnumerable<ArticleResponseDto>> GetAllArticleForUser()
        {
            return await _articleService.GetAllForUserAsync();
        }

        [Authorize]
        [HttpPut("update-article")]
        public async Task<IActionResult> UpdateArticle(ArticleRequestDto articleRequestDto)
        {
            var result = await _articleService.UpdateAsync(articleRequestDto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteArticle([FromBody] Guid articleId)
        {
            var result = await _articleService.DeleteAsync(articleId);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

    }
}
