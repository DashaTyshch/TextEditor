using DBModels;
using System;
using System.Web.Mvc;

namespace Tyshchenko_TextEditor.Controllers
{
    public class HomeController : Controller
    {
        private readonly TextEditorService.TextEditorContractClient textEditorService =
            new TextEditorService.TextEditorContractClient();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult History()
        {
            var user = textEditorService.GetUserByLogin(System.Web.HttpContext.Current.User.Identity.Name);

            return View(user.Queries);
        }

        [HttpGet]
        [Authorize]
        public ActionResult UploadFile(string path)
        {
            try
            {
                var _ = textEditorService.GetUserByLogin(System.Web.HttpContext.Current.User.Identity.Name);
                textEditorService.AddQuery(new Query(path, QueryStateEnum.Opened), _.Guid);
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result=false, message = ex.Message + ex.InnerException?.Message }, 
                    JsonRequestBehavior.AllowGet);
            }
        }
    }
}