using ForumAdminPanel.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ForumAdminPanel.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context) 
        {
            _context = context;
        } 
        public IActionResult Index()
        {   

            return View();
        }
    }
}
