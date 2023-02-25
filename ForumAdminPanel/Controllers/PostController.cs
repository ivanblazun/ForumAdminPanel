using ForumAdminPanel.Data;
using ForumAdminPanel.Interfaces;
using ForumAdminPanel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumAdminPanel.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPostRepository _postRepository;

        public PostController(ApplicationDbContext context, IPostRepository postRepository)
        {
            _context = context;
            _postRepository = postRepository;
        }
        public async Task<IActionResult> Index()
        {
            //var posts = await _postRepository.GetAllPosts();

            IEnumerable<Post> posts = await _postRepository.GetAllPosts();
            return View(posts);
        }

        public async Task<IActionResult> SinglePost(int id) 
        {
            bool doesPostExist = _context.Posts.Any(p => p.Id == id);
            //var requestedPost = _context.Posts.FirstOrDefault(p => p.Id == id);

            //bool doesPostExist = _postRepository.GetPostByIdAsync(id);  

            Post requestedPost = await _postRepository.GetPostByIdAsync(id);

            if (doesPostExist)
            {
                return View(requestedPost);
            }
            else 
            {
                return RedirectToAction("Index");
            }

        }
    }
}
