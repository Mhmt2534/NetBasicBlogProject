using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Like:BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }


        public Guid ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
