using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Article
{
    public class ArticleResponseDto
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public int LikeCount { get; set; } 
    }
}
