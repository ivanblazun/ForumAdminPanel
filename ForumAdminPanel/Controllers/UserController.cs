using ForumAdminPanel.Data;
using ForumAdminPanel.Interfaces;
using ForumAdminPanel.Models;
using ForumAdminPanel.Repository;
using ForumAdminPanel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ForumAdminPanel.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();

            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id.ToString(),
                    UserName = user.UserName,
                    RegisteredDate = user.RegisteredDate,
                    UserStatus = user.UserStatus,
                    Posts = user.Posts,
                    Answers = user.Answers,
                };

                result.Add(userViewModel);
            }

            return View(result);
        }

        //Get users filter 
        public async Task<IActionResult> SearchUserInput()
        {
            SearchString searchString = new SearchString();

            return View(searchString);        
        }

        //Get filtered users list
        public async Task<IActionResult> SearchUserResult(SearchString searchInput)
        {   
            string input=searchInput.Input;

            var  users= await _userRepository.GetUsersBySearchInput(input);

            List<UserViewModel> result = new List<UserViewModel>();

            if (users != null)
            {
                foreach (var user in users)
                {
                    var userViewModel = new UserViewModel()
                    {
                        Id = user.Id.ToString(),
                        UserName = user.UserName,
                        RegisteredDate = user.RegisteredDate,
                        UserStatus = user.UserStatus,
                        Posts = user.Posts,
                        Answers = user.Answers,
                    };

                    result.Add(userViewModel);
                }
                return View(result);
            }
            else 
            {
                return View(result);
            }
        }

        // Get single user
        public async Task<IActionResult> SingleUser(int id)
        {
            bool doesPostExist = _context.Posts.Any(p => p.Id == id);

            User user = await _userRepository.GetUserByIdAsync(id);

            if (doesPostExist)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // Get user by id from stored procedures

        public ActionResult GetUserByIdFromProc(int id)
        {
            User user = (User)_context.Users.FromSqlRaw<User>("Users_GetUserById {0}",id).ToList().FirstOrDefault();


            return View(); 
        }

        //Edit user action
        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            bool doesUserExist = _context.Users.Any(u => u.Id == id);

            if (!doesUserExist) { return View("User not found"); }
            else
            {
                var requestedUser = await _userRepository.GetUserByIdAsync(id);

                var userViewModel = new UpdateUserViewModel
                {
                    Id = id,
                    UserName= requestedUser.UserName,
                    Email= requestedUser.Email,
                    Password= requestedUser.Password,
                    RegisteredDate = requestedUser.RegisteredDate,
                    UserStatus = requestedUser.UserStatus,
                    //Posts = requestedUser.Posts,
                    //Answers = requestedUser.Answers,
                };
                return View(userViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserViewModel updateUsertViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to update post");
                return View("Edit", updateUsertViewModel);
            }

            var requestedUser = await _userRepository.GetUserByIdAsync(id);

            if (requestedUser != null)
            {
                requestedUser.Id = id;
                requestedUser.UserName = updateUsertViewModel.UserName;
                requestedUser.Email = updateUsertViewModel.Email;
                requestedUser.Password = updateUsertViewModel.Password;
                requestedUser.RegisteredDate = updateUsertViewModel.RegisteredDate;
                requestedUser.UserStatus = updateUsertViewModel.UserStatus;
                //requestedUser.Posts = updateUsertViewModel.Posts;
                //requestedUser.Answers = updateUsertViewModel.Answers;

                _userRepository.UpdateUser(requestedUser);

                return RedirectToAction("Index");
            }
            else
            {
                return null;
            }
        }
    }
}
