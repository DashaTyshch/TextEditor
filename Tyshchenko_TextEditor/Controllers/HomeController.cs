using DBModels;
using System;
using System.Linq;
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
            
            return View(user.Queries.OrderByDescending(q => q.QueryDate));
        }

        [HttpGet]
        [Authorize]
        public ActionResult UploadFile(string path)
        {
            try
            {
                var _ = textEditorService.GetUserByLogin(System.Web.HttpContext.Current.User.Identity.Name);
                Query query = new Query(path, QueryStateEnum.Opened);
                textEditorService.AddQuery(query, _.Guid);

                return Json(new { result = true, query.Guid}, 
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { result=false, message = ex.Message + ex.InnerException?.Message }, 
                    JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult SaveFile(Guid guid, bool isEdited)
        {
            try
            {
                var query = textEditorService.GetQueryByGuid(guid);
                query.State = isEdited ? QueryStateEnum.Edited : QueryStateEnum.NotEdited;
                textEditorService.SaveQuery(query);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message + ex.InnerException?.Message });
            }
        }
    }
}