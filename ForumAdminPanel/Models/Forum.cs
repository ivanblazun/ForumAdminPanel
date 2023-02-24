﻿

namespace ForumAdminPanel.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ThemesCounter { get; set; }
        public int UserCounter { get; set; }

        // Navigation props
        public List<Theme> Posts { get; set; }
    }
}
