using FundooNotes.Models;

namespace FundooNotes.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int userId);
        Task<User?> GetByEmailAsync(string email);
        Task<User> AddAsync(User user);
        Task<User?> UpdateAsync(User user);
    }
}
