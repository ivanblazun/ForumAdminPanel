using ForumAdminPanel.Models;

namespace ForumAdminPanel.Interfaces
{
    public interface IForumRepository
    {
        Task<IEnumerable<Fora>> GetAllForums();

        Task<Fora> GetForumById(int id);

        // Filter forums interf.
        Task<IEnumerable<Fora>> GetForumsBySearchInput(string searchInput);
    }
}
