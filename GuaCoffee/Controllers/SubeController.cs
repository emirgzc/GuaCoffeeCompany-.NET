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
	public class SubeController : Controller
	{
		SubeValidator validationRules = new SubeValidator();
		SubeManager sm = new SubeManager(new EfSubeDal());
		[AllowAnonymous]
		public ActionResult Index()
		{
			var subeList = sm.GetListStatusTrue();
			return View(subeList);
		}
		public ActionResult ASubeList()
		{
			var menuList = sm.GetAll();
			return View(menuList);
		}
		[HttpGet]
		public ActionResult ASubeAdd()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ASubeAdd(Sube m)
		{
			ValidationResult result = validationRules.Validate(m);
			if (result.IsValid)
			{
				m.Status = true;
				sm.SubeAdd(m);
				return RedirectToAction("ASubeList");
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
		[HttpGet]
		public ActionResult ASubeUpdate(int id)
		{
			var menuID = sm.GetByID(id);
			return View(menuID);
		}
		[HttpPost]
		public ActionResult ASubeUpdate(Sube m)
		{
			ValidationResult result = validationRules.Validate(m);
			if (result.IsValid)
			{
				m.Status = false;
				sm.SubeUpdate(m);
				return RedirectToAction("ASubeList");
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
		public ActionResult ASubeDoFalse(int id)
		{
			var idmenu = sm.GetByID(id);
			idmenu.Status = false;
			sm.SubeUpdate(idmenu);
			return RedirectToAction("ASubeList");
		}
		public ActionResult ASubeDoTrue(int id)
		{
			var idmenu = sm.GetByID(id);
			idmenu.Status = true;
			sm.SubeUpdate(idmenu);
			return RedirectToAction("ASubeList");
		}
		public ActionResult ASubeDelete(int id)
		{
			var idmenu = sm.GetByID(id);
			sm.SubeDelete(idmenu);
			return RedirectToAction("ASubeList");
		}
	}
}