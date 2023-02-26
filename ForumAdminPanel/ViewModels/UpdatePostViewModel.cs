using ForumAdminPanel.Models;

namespace ForumAdminPanel.ViewModels
{
    public class UpdatePostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Value { get; set; }

        public int ThemeId { get; set; }
        public int AnswerId { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
