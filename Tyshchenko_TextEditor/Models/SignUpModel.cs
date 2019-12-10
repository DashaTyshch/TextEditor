using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Tyshchenko_TextEditor.Models
{
    public class SignUpModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please, enter your first name")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please, enter your last name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login is required")]
        [Remote("IsLoginAvailable", "Login", ErrorMessage = "Such login exists!")]
        public string LoginSU { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string PasswordSU { get; set; }
    }
}