using ForumAdminPanel.Data;
using ForumAdminPanel.Interfaces;
using ForumAdminPanel.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumAdminPanel.Repository
{
    public class PostRepository : IPostRepository
    {   
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // Get all posts
        public async Task<IEnumerable<Post>> GetAllPosts()
        {
              return await _context.Posts.Include(i=>i.Theme).ToListAsync();
        }

        //Get single post
        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _context.Posts.Include(i=>i.Answers).Include(i=>i.User).Include(i=>i.Theme).FirstOrDefaultAsync(p => p.Id == id);
        }

        //Add post
        public bool AddPost(Post post)
        {
            _context.Add(post);
            return Save();    
        }

        //delete post
        public bool DeletePost(Post post)
        {
            _context.Remove(post);
            return Save();
        }

        //Probably dont need but...
        public bool DeletePostById(int id)
        {
            throw new NotImplementedException();
        }
        

        public bool Save()
        {
            var saved = _context.SaveChanges(); 

            return saved > 0 ? true : false;    
        }

        public bool UpdatePost(Post post)
        {
            _context.Update(post);
            return Save();

        }
    }
}
