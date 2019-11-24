using DBModels;
using System.Web.Mvc;
using Tyshchenko_TextEditor.Models;
using System.Web.Security;

namespace Tyshchenko_TextEditor.Controllers
{
    public class LoginController : Controller
    {
        private readonly TextEditorService.TextEditorContractClient textEditorService = 
            new TextEditorService.TextEditorContractClient();

        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [AllowAnonymous]
        public ActionResult Signin(SignInModel user)
        {
            if (textEditorService.UserExists(user.Login))
            {
                User _ = textEditorService.GetUserByLogin(user.Login);
                FormsAuthentication.SetAuthCookie(_.Login, true);
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Signup(SignUpModel user)
        {
            textEditorService.AddUser(
                new User(user.FirstName, user.LastName, user.Email, user.Login, user.Password));

            FormsAuthentication.SetAuthCookie(user.Login, true);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}