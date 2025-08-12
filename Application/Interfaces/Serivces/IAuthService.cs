using Application.DTOs.Auth;
using Application.DTOs.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Serivces
{
    public interface IAuthService
    {
        Task<TokenResponseDto> LoginAsync(UserDto request);
        Task<User> RegisterAsync(UserDto request);
        Task<TokenResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request);
    }
}
