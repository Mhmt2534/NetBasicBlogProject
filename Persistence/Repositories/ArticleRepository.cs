using Application.Interfaces.Repositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        private readonly BlogDbContext _dbContext;
        public ArticleRepository(BlogDbContext dbContext) : base(dbContext) 
        { 
            _dbContext = dbContext;
        }
    }
}
