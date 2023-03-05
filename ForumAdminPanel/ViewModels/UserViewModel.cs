using ForumAdminPanel.Models;

namespace ForumAdminPanel.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public DateTime RegisteredDate { get; set; }

        public int UserStatus { get; set; }

        // Navigation props

        public List<Post> Posts { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
