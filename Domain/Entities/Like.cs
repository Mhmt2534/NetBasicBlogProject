using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Like
    {
        public Guid UserId { get; set; }
        public User User { get; set; }


        public Guid ArticleId { get; set; }
        public Article Article { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedTime { get; set; }
        public bool IsDelete { get; set; }

    }
}
