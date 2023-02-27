using ForumAdminPanel.Data;
using ForumAdminPanel.Interfaces;
using ForumAdminPanel.Models;
using ForumAdminPanel.ViewModels;
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

        //All posts action
        public async Task<IActionResult> Index()
        {
            //var posts = await _postRepository.GetAllPosts();

            IEnumerable<Post> posts = await _postRepository.GetAllPosts();
            return View(posts);
        }

        //Single post action
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

        //Edit post action
        public async Task<IActionResult> UpdatePost(int id) 
        {
            bool doesPostExist = _context.Posts.Any(p => p.Id == id);

            if (!doesPostExist) { return View("Post not found"); }
            else 
            {
                var requestedPost = await _postRepository.GetPostByIdAsync(id);

                var postViewModel = new UpdatePostViewModel 
                {

                    Title = requestedPost.Title,
                    Body = requestedPost.Body,
                    Value = requestedPost.Value,
                    ThemeId = requestedPost.ThemeId,
                    AnswerId = requestedPost.AnswerId,
                    Answers = requestedPost.Answers,

                };
                return View(postViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(int id, UpdatePostViewModel updatePostViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to update post");
                return View("Edit", updatePostViewModel);
            }
           
            var requestedPost = await _postRepository.GetPostByIdAsync(id);

            if (requestedPost != null)
            {
                requestedPost.Title = updatePostViewModel.Title;
                requestedPost.Body = updatePostViewModel.Body;  
                requestedPost.Value = updatePostViewModel.Value;
                requestedPost.ThemeId = updatePostViewModel.ThemeId;
                requestedPost.AnswerId = updatePostViewModel.AnswerId;
                requestedPost.Answers = updatePostViewModel.Answers;

                _postRepository.UpdatePost(requestedPost);
            
                return RedirectToAction("Index");
            
            }
            else
            {
                return null;
            }
        }
    }
}
