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
    public class FranchiseController : Controller
    {
        FranchiseManager fm = new FranchiseManager(new EfFranchiseDal());
        [HttpGet]
		[AllowAnonymous]
		public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
		[AllowAnonymous]
		public ActionResult Index(Franchise f)
		{
            f.DateFran = DateTime.Parse(DateTime.Now.ToLongTimeString());
            f.Status = true;
            fm.FranchiseAdd(f);
            return RedirectToAction("Index");
		}
		public ActionResult AFranchiseList()
		{
			var list = fm.GetOrderByDate();
			return View(list);
		}
		public ActionResult AFranchiseDetails(int id)
		{
			var contact = fm.GetByID(id);
			return View(contact);
		}
		public ActionResult AFranchiseDelete(int id)
		{
			var contact = fm.GetByID(id);
			fm.FranchiseDelete(contact);
			return RedirectToAction("AFranchiseList");
		}
	}
}