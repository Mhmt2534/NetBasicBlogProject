using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Header { get; set; }
        public string Content { get; set; }

        public Guid AuthorId { get; set; }
        public User Author { get; set; }

        public ICollection<Like> Likes { get; set; }
        
    }
}
