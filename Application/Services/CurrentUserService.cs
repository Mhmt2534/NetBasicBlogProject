using Application.Interfaces.Serivces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetCurrentUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User??
                throw new UnauthorizedAccessException("User not found in HttpContext");


            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value??
                throw new UnauthorizedAccessException("User ID claim not found.");

            return Guid.Parse(userIdClaim);
        }

        public string GetCurrentUserName()
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated()
        {
            throw new NotImplementedException();
        }
    }
}
