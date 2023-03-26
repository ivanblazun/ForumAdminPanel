using ForumAdminPanel.Data;
using ForumAdminPanel.Interfaces;
using ForumAdminPanel.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumAdminPanel.Repository
{
    public class ForumRepository : IForumRepository
    {   
        private readonly ApplicationDbContext _context;

        public ForumRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all forums 
        public async Task<IEnumerable<Fora>> GetAllForums()
        {
            return await _context.Fora.ToListAsync();
        }
        // Get forum by id
        public async Task<Fora> GetForumById(int id)
        {
            return await _context.Fora.FirstOrDefaultAsync(f=>f.Id==id);
        }

        public async Task<IEnumerable<Fora>> GetForumsBySearchInput(string searchInput)
        {

            //Fora searchedForum = await _context.Fora.Where(f => f.Name.Contains(searchInput).ToString() == searchInput).FirstOrDefaultAsync();

            //List<Theme> themes = searchedForum.Themes;

            //List<Theme> foundedThemes=new List<Theme>();

            //foreach (var theme in themes) 
            //{
            //    if (theme.Title == searchInput)
            //    { 
            //        themes.Add(theme);
            //    }
            //}

            return await _context.Fora
                .Include(f => f.Themes)
                .Where(f => f.Name.Contains(searchInput))
                .ToListAsync();  
                 

        }
    }
}
