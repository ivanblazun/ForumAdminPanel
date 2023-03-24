using ForumAdminPanel.Models;
using ForumAdminPanel.ViewModels;

namespace ForumAdminPanel.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserByIdAsync(int id);

        // Get user by id from proc
        Task <IEnumerable<User>> GetUserByIdProc(int id);

        // Filter user interf.
        Task <IEnumerable<User>> GetUsersBySearchInput(string searchInput);

        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool DeleteUserById(int id);
        bool Save();
    }
}
