using Library.DataLayer.DatabaseData;
using Library.DomainLayer.Models;
using Library.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _dbContext;

        public UserRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetUserAsync(string email)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
