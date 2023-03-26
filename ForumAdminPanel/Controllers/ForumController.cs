using ForumAdminPanel.Data;
using ForumAdminPanel.Interfaces;
using ForumAdminPanel.Models;
using ForumAdminPanel.Repository;
using ForumAdminPanel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ForumAdminPanel.Controllers
{
    public class ForumController : Controller
    {   
        private readonly ApplicationDbContext _context;
        private readonly IForumRepository _forumRepository;

        public ForumController(ApplicationDbContext context, IForumRepository forumRepository)
        {
            _context = context;
            _forumRepository = forumRepository;
        }

        // All forums action
        public async Task< IActionResult> Index()
        {
            IEnumerable<Fora> forums = await _forumRepository.GetAllForums();

            return View(forums);
        }

        public async Task<IActionResult> SingleForum(int id)
        {
            Fora forum = await _forumRepository.GetForumById(id);

            return View(forum);
        }

        //Get users filter 
        public async Task<IActionResult> SearchForumInput()
        {
            SearchString searchString = new SearchString();

            return View(searchString);
        }

        //Get filtered forums list
        public async Task<IActionResult> SearchForumResult(SearchString searchInput)
        {
            string input = searchInput.Input;

            var forums = await _forumRepository.GetForumsBySearchInput(input);

            List<ForumViewModel> result = new List<ForumViewModel>();

            if (forums != null)
            {
                foreach (var forum in forums)
                {
                    var forumViewModel = new ForumViewModel()
                    {
                        Id = forum.Id.ToString(),
                        Name = forum.Name,  
                        ThemesCounter= forum.ThemesCounter,
                        UserCounter= forum.UserCounter,
                        MainForumId=forum.MainForumId
                    };

                    result.Add(forumViewModel);
                }
                return View(result);
            }
            else
            {
                return View(result);
            }
        }
    }
}
