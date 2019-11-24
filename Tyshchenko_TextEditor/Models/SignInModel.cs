using System.ComponentModel.DataAnnotations;

namespace Tyshchenko_TextEditor.Models
{
    public class SignInModel
    {
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}