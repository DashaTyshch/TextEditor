
namespace Tyshchenko_TextEditor.Models
{
    public class LoginModel
    {
        public SignInModel SignIn { get; set; } = new SignInModel();
        public SignUpModel SignUp { get; set; } = new SignUpModel();
    }
}