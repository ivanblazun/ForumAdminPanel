using ForumAdminPanel.Data;
using ForumAdminPanel.Interfaces;
using ForumAdminPanel.Models;
using ForumAdminPanel.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ForumAdminPanel.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {   
            return await _context.Users.Include(u=>u.Posts).Include(u=>u.Answers).FirstOrDefaultAsync(u=>u.Id== id);
        }

        public async Task <IEnumerable<User>> GetUserByIdProc(int id)
        {
            return await (IEnumerable<User>)_context.Users.FromSqlRaw<User>("Users_GetUserById {0}", id).ToList().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersBySearchInput(string searchInput)
        {
            return await _context.Users
                .Include(u => u.Posts)
                .Include(u => u.Answers)
                .Where(u => u.UserName.Contains(searchInput) || u.Email.Contains(searchInput)).ToListAsync();
        }

        public bool Save()
        {
            var saved =_context.SaveChanges();
            return saved> 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Users.Update(user);
            return Save();
        }
    }
}
