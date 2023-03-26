using ForumAdminPanel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumAdminPanel.Data
{
    public class ApplicationDbContext : IdentityDbContext<AdminAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Fora> Fora { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<MainForum> MainForums { get; set; }


    }
}
