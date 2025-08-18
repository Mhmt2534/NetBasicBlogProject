using Application.Interfaces.Serivces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;
        private readonly ICurrentUserService _currentUserService;

        public LikeController(ILikeService likeService, ICurrentUserService currentUserService)
        {
            _likeService = likeService;
            _currentUserService = currentUserService;
        }

        [Authorize]
        [HttpPost("click-like")]
        public async Task<IActionResult> clickLike([FromBody] Guid articleId)
        {
            Guid currenUser = _currentUserService.GetCurrentUserId(); //mevcut kullanıcıyı çekiyoruz.

            Like newLike = new Like
            {
                ArticleId = articleId,
                UserId = currenUser
            };

            var result = await _likeService.AddAsync(newLike);
            return Ok(result.Message);
        }


    }
}
