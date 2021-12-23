using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuaCoffee.Controllers
{
	public class ActivityController : Controller
	{
		ActivityValidator validationRules = new ActivityValidator();
		ActivityManager acm = new ActivityManager(new EfActivityDal());
		Context c = new Context();
		[AllowAnonymous]
		public ActionResult Index()
		{
			var actList = acm.GetStatusTrue();
			return View(actList);
		}
		[AllowAnonymous]
		public ActionResult ActivityDetails(int id)
		{
			var actidList = acm.GetActivityByID(id);
			return View(actidList);
		}
		public ActionResult AActivityList()
		{
			var actidList = acm.GetOrderByDate();
			return View(actidList);
		}
		[HttpGet]
		public ActionResult ANewAct()
		{
			return View();
		}
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult ANewAct(Activity b)
		{
			ValidationResult result = validationRules.Validate(b);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
			string way = "~/Image/Activity/" + filename;
			b.Image = "/Image/Activity/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						b.DateAct = DateTime.Parse(DateTime.Now.ToLongTimeString());
						b.Status = true;
						acm.ActivitytAdd(b);
						return RedirectToAction("AActivityList");
					}
					else
					{
						foreach (var item in result.Errors)
						{
							ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
						}
					}
				}
				else
				{
					ViewBag.hata = "Dosya uzantısı yükleme için uygun değil. Uygun olan uzantılar : .jpg, .jpeg, .png";
				}
			}
			return View();
		}
		public ActionResult ADeleteActivity(int id)
		{
			var idgal = acm.GetByID(id);
			var filename = Request.MapPath("~" + idgal.Image);
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			acm.ActivityDelete(idgal);
			return RedirectToAction("AActivityList");
		}
		public ActionResult AActivityDoFalse(int id)
		{
			var idser = acm.GetByID(id);
			idser.Status = false;
			acm.ActivityUpdate(idser);
			return RedirectToAction("AActivityList");
		}
		public ActionResult AActivityDoTrue(int id)
		{
			var idser = acm.GetByID(id);
			idser.Status = true;
			acm.ActivityUpdate(idser);
			return RedirectToAction("AActivityList");
		}
		[HttpGet]
		public ActionResult AActivityUpdate(int id)
		{
			var idserv = acm.GetByID(id);
			return View(idserv);
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult AActivityUpdate(Activity b)
		{
			ValidationResult result = validationRules.Validate(b);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);

			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 999999999).ToString() + uzanti;

			string way = "~/Image/Activity/" + filename;
			b.Image = "/Image/Activity/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						b.DateAct = DateTime.Parse(DateTime.Now.ToLongTimeString());
						b.Status = false;
						acm.ActivityUpdate(b);
						return RedirectToAction("AActivityList");
					}
					else
					{
						foreach (var item in result.Errors)
						{
							ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
						}
					}
				}
				else
				{
					ViewBag.hata = "Dosya uzantısı yükleme için uygun değil. Uygun olan uzantılar : .jpg, .jpeg, .png";
				}
			}
			if (!System.IO.File.Exists(b.Image))
			{
				if (result.IsValid)
				{
					string resim = c.Activities.Where(x => x.ActID == b.ActID).Select(z => z.Image).FirstOrDefault();
					b.Image = resim;
					b.Status = false;
					b.DateAct = DateTime.Parse(DateTime.Now.ToLongTimeString());
					acm.ActivityUpdate(b);
					return RedirectToAction("AActivityList");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
					}
				}

			}
			return View();
		}
	}
}