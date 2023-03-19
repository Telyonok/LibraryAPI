using Library.Domain.Abstractions;
using Library.Domain.Data;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        IServiceScopeFactory scopeFactory;

        public UserRepository(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public async Task<User?> GetUserAsync(string email)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                return _db.Users.AsNoTracking().FirstOrDefault(x => x.Email == email);
            }
        }
    }
}
