using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using datalayer;
using System.Web.Security;

namespace mycms.Controllers
{
    public class accountController : Controller
    {
        // GET: accont
       private Iloginrepository loginrepository;
        private mycmscontext db = new mycmscontext();
        public accountController()
        {
            loginrepository = new loginrepository(db);
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(loginviewmodel lv,string returnurl= "/account/management")
        {
            if (ModelState.IsValid)
            {
                if (loginrepository.isexistuser(lv.username, lv.password))
                {
                    FormsAuthentication.SetAuthCookie(lv.username, lv.rememberme);
                    return Redirect(returnurl);

                }
                else
                {
                    ModelState.AddModelError("username", "کاربری یافت نشد");

                }
            }
            return View(lv);
        }
        public ActionResult signout()
        {
             FormsAuthentication.SignOut();
            return Redirect("/");
        }
        public ActionResult management()
        {
            return View();
        }
    }
}