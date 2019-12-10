using System.ComponentModel.DataAnnotations;

namespace Tyshchenko_TextEditor.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Login is required")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}