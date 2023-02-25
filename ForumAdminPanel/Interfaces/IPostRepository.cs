using ForumAdminPanel.Models;

namespace ForumAdminPanel.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPosts();
        Task<Post> GetPostByIdAsync(int id);

        bool AddPost(Post post);
        bool UpdatePost(Post post);
        bool DeletePost(Post post);
        bool DeletePostById(int id);
        bool Save();                
    }
}
