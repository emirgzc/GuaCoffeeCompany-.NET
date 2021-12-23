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
	public class ShopController : Controller
	{
		StoreValidator validationRules = new StoreValidator();
		StoreManager sm = new StoreManager(new EfStoreDal());
		Context c = new Context();
		[AllowAnonymous]
		public ActionResult Index()
		{
			var storeList = sm.GetListStatusTrue();
			return View(storeList);
		}
		[AllowAnonymous]
		public ActionResult StoreDetails(int id)
		{
			var storeList = sm.GetStoreByID(id);
			return View(storeList);
		}
		public ActionResult AStoreList()
		{
			var actidList = sm.GetOrderByDate();
			return View(actidList);
		}
		[HttpGet]
		public ActionResult ANewStore()
		{
			return View();
		}
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult ANewStore(Store b)
		{

			ValidationResult result = validationRules.Validate(b);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
			string way = "~/Image/Store/" + filename;
			b.Image = "/Image/Store/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						b.DateStore = DateTime.Parse(DateTime.Now.ToLongTimeString());
						b.Status = true;
						sm.StoreAdd(b);
						return RedirectToAction("AStoreList");
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
		public ActionResult ADeleteStore(int id)
		{
			var idgal = sm.GetByID(id);
			var filename = Request.MapPath("~" + idgal.Image);
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			sm.StoreDelete(idgal);
			return RedirectToAction("AStoreList");
		}
		public ActionResult AStoreDoFalse(int id)
		{
			var idser = sm.GetByID(id);
			idser.Status = false;
			sm.StoreUpdate(idser);
			return RedirectToAction("AStoreList");
		}
		public ActionResult AStoreDoTrue(int id)
		{
			var idser = sm.GetByID(id);
			idser.Status = true;
			sm.StoreUpdate(idser);
			return RedirectToAction("AStoreList");
		}
		[HttpGet]
		public ActionResult AStoreUpdate(int id)
		{
			var idserv = sm.GetByID(id);
			return View(idserv);
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult AStoreUpdate(Store b)
		{
			ValidationResult result = validationRules.Validate(b);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);

			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 999999999).ToString() + uzanti;

			string way = "~/Image/Store/" + filename;
			b.Image = "/Image/Store/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						b.DateStore = DateTime.Parse(DateTime.Now.ToLongTimeString());
						b.Status = false;
						sm.StoreUpdate(b);
						return RedirectToAction("AStoreList");
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
					string resim = c.Stores.Where(x => x.StoreID == b.StoreID).Select(z => z.Image).FirstOrDefault();
					b.Image = resim;
					b.Status = false;
					b.DateStore = DateTime.Parse(DateTime.Now.ToLongTimeString());
					sm.StoreUpdate(b);
					return RedirectToAction("AStoreList");
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