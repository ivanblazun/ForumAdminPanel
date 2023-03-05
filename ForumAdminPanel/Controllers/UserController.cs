using ForumAdminPanel.Data;
using ForumAdminPanel.Interfaces;
using ForumAdminPanel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ForumAdminPanel.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        } 
        public async Task<IActionResult> Index()
        {   
            var users= await _userRepository.GetAllUsers();

            List<UserViewModel> result= new List<UserViewModel>();
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
    }
}
