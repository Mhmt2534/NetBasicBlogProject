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
    public interface ILikeService
    {
        Task<SuccessResult> AddAsync(Like like);
        Task<int> getLikeCount(Guid articleId);

    }
}
