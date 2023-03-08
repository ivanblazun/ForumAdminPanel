using ForumAdminPanel.Models;

namespace ForumAdminPanel.ViewModels
{
    public class UpdateUserViewModel
    {
        public int Id { get; set; }
        
        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public DateTime RegisteredDate { get; set; }

        public int UserStatus { get; set; }

        public List<Post> Posts { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
