using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository //Burdaki GenericRepom ile miras aldık bir daha yazmayız
    {
        private readonly BlogDbContext _dbContext;
        public UserRepository(BlogDbContext dbContext) : base(dbContext)  //Burda base ile bir üste yani generice göndeiryoruz.
        { 
            _dbContext = dbContext;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<bool> UserIsExist(string username)
        {
            return await _dbContext.Users.AnyAsync(x => x.UserName == username);
        }
    }
}
