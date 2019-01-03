using CURD.Business.Helper;
using CURD.Business.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CURDWeb.Controllers
{
    public class AccountController : Controller
    {
        

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        public JsonResult Add(UserViewModel user)
        {

            if (user?.userid!=0)
            {
                var result = ApiHelper.SendApiRequest(user, "user/Update", HttpMethod.Put);
                return Json(result.Success, JsonRequestBehavior.AllowGet);
            }
            var response = ApiHelper.SendApiRequest(user, "user/post", HttpMethod.Post);
            return Json(response.Success, JsonRequestBehavior.AllowGet);
           
        }
        public JsonResult List()
        {
            var response = ApiHelper.SendApiRequest("", "user", HttpMethod.Get);
            if (response.Success)
            {
                var result = JsonConvert.DeserializeObject<List<UserViewModel>>(response.Data.ToString());
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(response.Success, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UserById(long id)
        {
            var response = ApiHelper.SendApiRequest("?id="+id, "user", HttpMethod.Get);
            if (response.Success)
            {
                var user= JsonConvert.DeserializeObject<UserViewModel>(response.Data.ToString());
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            return Json(response.Success, JsonRequestBehavior.AllowGet);
        }
    }
}