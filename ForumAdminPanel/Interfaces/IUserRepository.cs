using ForumAdminPanel.Models;

namespace ForumAdminPanel.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserByIdAsync(int id);

        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool DeleteUserById(int id);
        bool Save();
    }
}
