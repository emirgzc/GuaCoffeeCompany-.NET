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
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        SettingManager sm = new SettingManager(new EfSettingDal());
        [HttpGet]
		[AllowAnonymous]
		public ActionResult Index()
        {
            var setList = sm.GetAll();
            return View(setList);
        }
        [HttpPost]
		[AllowAnonymous]
		public ActionResult Index(Contact c)
		{
            c.DateMessage = DateTime.Parse(DateTime.Now.ToLongTimeString());
            cm.ContactAdd(c);
            return RedirectToAction("Index");
		}
		public ActionResult AContactList()
		{
			var list = cm.GetOrderByDate();
			return View(list);
		}
		public ActionResult AContactDetails(int id)
		{
			var contact = cm.GetByID(id);
			return View(contact);
		}
		public ActionResult AContactDelete(int id)
		{
			var contact = cm.GetByID(id);
			cm.ContactDelete(contact);
			return RedirectToAction("AContactList");
		}
	}
}