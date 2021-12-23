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
	public class SliderController : Controller
	{
		SliderValidator validationRules = new SliderValidator();
		SliderManager sm = new SliderManager(new EfSliderDal());
		SettingManager ssm = new SettingManager(new EfSettingDal());
		Context c = new Context();
		[AllowAnonymous]
		public ActionResult Index()
		{
			var sliderList = sm.GetAll();
			return View(sliderList);
		}
		[AllowAnonymous]
		public PartialViewResult Footer()
		{
			var setlislt = ssm.GetAll();
			return PartialView(setlislt);
		}
		public ActionResult ASliderList()
		{
			var list = sm.GetAll();
			return View(list);
		}
		[HttpGet]
		public ActionResult ASliderUpdate(int id)
		{
			var idserv = sm.GetByID(id);
			return View(idserv);
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult ASliderUpdate(Slider s)
		{
			ValidationResult result = validationRules.Validate(s);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);
			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 9999999).ToString() + uzanti;
			string way = "~/Image/Slider/" + filename;
			s.Image = "/Image/Slider/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						sm.SliderUpdate(s);
						return RedirectToAction("ASliderList");
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
			if (!System.IO.File.Exists(s.Image))
			{
				if (result.IsValid)
				{
					string resim = c.Sliders.Where(x => x.SliderID == s.SliderID).Select(z => z.Image).FirstOrDefault();
					s.Image = resim;
					sm.SliderUpdate(s);
					return RedirectToAction("ASliderList");
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