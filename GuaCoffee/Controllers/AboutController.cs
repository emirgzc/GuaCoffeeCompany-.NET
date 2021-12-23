using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuaCoffee.Controllers
{
	public class AboutController : Controller
	{
		AboutManager abm = new AboutManager(new EfAboutDal());
		AboutValidator validationRules = new AboutValidator();
		[AllowAnonymous]
		public ActionResult Index()
		{
			var aboutlist = abm.GetAll();
			return View(aboutlist);
		}
		public ActionResult AAboutList()
		{
			var aboutList = abm.GetAll();
			return View(aboutList);
		}
		[HttpGet]
		public ActionResult AAboutUpdate(int id)
		{
			var aboutID = abm.GetByID(id);
			return View(aboutID);
		}
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult AAboutUpdate(About a)
		{
			ValidationResult result = validationRules.Validate(a);
			if (result.IsValid)
			{
				abm.AboutUpdate(a);
				return RedirectToAction("AAboutList");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
	}
}