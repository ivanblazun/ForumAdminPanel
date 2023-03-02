using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace ForumAdminPanel.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name ="Email")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name ="password")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }

        [Display(Name ="Confirm Password")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Cconfirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passwords must match")]
        public string ConfirmPassword { get; set; }
    }
}
