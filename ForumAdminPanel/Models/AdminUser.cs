using System.ComponentModel.DataAnnotations;

namespace ForumAdminPanel.Models
{
    public class AdminUser
    {
        public int? Pace { get; set; }
        public int? Mileage { get; set; }
        public Address? Address { get; set; }
    }
}
