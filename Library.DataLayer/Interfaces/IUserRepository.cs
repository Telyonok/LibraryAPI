using Library.DomainLayer.Models;

namespace Library.DataLayer.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetUserAsync(string email);
    }
}
