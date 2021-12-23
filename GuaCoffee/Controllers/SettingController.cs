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
	public class SettingController : Controller
	{
		SettingValidator validationRules = new SettingValidator();
		SettingManager sm = new SettingManager(new EfSettingDal());
		[AllowAnonymous]
		public PartialViewResult TopBarSetting()
		{
			var setList = sm.GetAll();
			return PartialView(setList);
		}
		public ActionResult ASetList()
		{
			var setlist = sm.GetAll();
			return View(setlist);
		}
		[HttpGet]
		public ActionResult ASettingUpdate(int id)
		{
			var set = sm.GetByID(id);
			return View(set);
		}
		[HttpPost]
		public ActionResult ASettingUpdate(Setting a)
		{
			ValidationResult result = validationRules.Validate(a);

			if (result.IsValid)
			{
				sm.SettingUpdate(a);
				return RedirectToAction("ASetList");
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