using AngularJsMvc.DbModel;
using AngularJsMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJsMvc.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetLastContact()
        {
            Contact c = null;
            using (AngularJsModelEntities e = new AngularJsModelEntities())
            {
                c = e.Contact.OrderByDescending(o => o.Id).Take(1).FirstOrDefault();
            }

            return new JsonResult
            {
                Data = c,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult UserLogin(LoginData d)
        {
            using (AngularJsModelEntities dc = new AngularJsModelEntities())
            {
                var user = dc.User.Where(a => a.Username.ToLower().Equals(d.Username.ToLower()) 
                                                    && 
                                                a.Password.ToLower().Equals(d.Password.ToLower()))
                                    .FirstOrDefault();
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}