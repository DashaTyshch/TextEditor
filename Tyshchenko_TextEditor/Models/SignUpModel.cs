using System.ComponentModel.DataAnnotations;

namespace Tyshchenko_TextEditor.Models
{
    public class SignUpModel
    {
        [Display(Name = "Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Login")]
        [Required]
        public string Login { get; set; }

        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }
    }
}