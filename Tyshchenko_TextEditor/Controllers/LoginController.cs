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
            return View(new LoginModel());
        }

        [AllowAnonymous]
        public ActionResult Signin(SignInModel signInUser)
        {
            if (ModelState.IsValid)
            {
                if (textEditorService.UserExists(signInUser.Login))
                {
                    User user = textEditorService.GetUserByLogin(signInUser.Login);
                    if(user.CheckPassword(signInUser.Password))
                    {
                        FormsAuthentication.SetAuthCookie(user.Login, true);
                        return RedirectToAction("Index", "Home");
                    } else
                        ModelState.AddModelError("Password", "The password is incorrect");

                }
                else
                    ModelState.AddModelError("Login", "The username is incorrect");
            }

            var model = new LoginModel() { SignIn = signInUser};
            return View("Login", model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Signup(SignUpModel signUpUser)
        {
            if(ModelState.IsValid)
            {
                textEditorService.AddUser(
                    new User(signUpUser.FirstName, signUpUser.LastName, signUpUser.Email,
                        signUpUser.LoginSU, signUpUser.PasswordSU));

                FormsAuthentication.SetAuthCookie(signUpUser.LoginSU, true);
                return Json(new { result = true,
                    url = Url.Action("Index", "Home")
                });
            }
            
            return Json(new { result = false});
        }

        [HttpGet]
        public JsonResult IsLoginAvailable(string loginSU)
        {
            return Json(!textEditorService.UserExists(loginSU), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}