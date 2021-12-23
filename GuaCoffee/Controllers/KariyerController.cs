using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuaCoffee.Controllers
{
    public class KariyerController : Controller
    {
        KariyerManager km = new KariyerManager(new EfKariyerDal());
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Kariyer k)
        {
            k.DateKar = DateTime.Parse(DateTime.Now.ToLongTimeString());
            k.Status = true;
            km.KariyerAdd(k);
            return RedirectToAction("Index");
        }
        public ActionResult AKariyerList()
        {
            var list = km.GetOrderByDate();
            return View(list);
        }
        public ActionResult AKariyerDetails(int id)
        {
            var contact = km.GetByID(id);
            return View(contact);
        }
        public ActionResult AKariyerDelete(int id)
        {
            var contact = km.GetByID(id);
            km.KariyerDelete(contact);
            return RedirectToAction("AKariyerList");
        }
    }
}