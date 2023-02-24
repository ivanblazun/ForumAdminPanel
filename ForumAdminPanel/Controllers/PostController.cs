using ForumAdminPanel.Data;
using Microsoft.AspNetCore.Mvc;

namespace ForumAdminPanel.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var posts = _context.Posts.ToList();

            return View(posts);
        }

        public int DeletePostFromDb(int postid) 
        {
            var requiredPost = _context.Posts.Where(p => p.Id == postid).FirstOrDefault();

            bool doespostExist = _context.Posts.Any(p => p.Id == postid);

            if (doespostExist)
            {
                return 0;
            }
            else 
            {
                return 1;
            }

        }

    }
}
