using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuaCoffee.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult PageDefault()
        {
            return View();
        }
    }
}