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
	public class MenuController : Controller
	{
		MenuManager mm = new MenuManager(new EfMenuDal());
		MenuValidator validationRules = new MenuValidator();
		[AllowAnonymous]
		public ActionResult Index()
		{
			var menuList = mm.GetStatusByTrue();
			return View(menuList);
		}
		public ActionResult AMenuList()
		{
			var menuList = mm.GetAll();
			return View(menuList);
		}
		[HttpGet]
		public ActionResult AMenuAdd()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AMenuAdd(Menu m)
		{
			ValidationResult result = validationRules.Validate(m);
			if (result.IsValid)
			{
				m.Status = true;
				mm.MenuAdd(m);
				return RedirectToAction("AMenuList");
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
		public ActionResult AMenuUpdate(int id)
		{
			var menuID = mm.GetByID(id);
			return View(menuID);
		}
		[HttpPost]
		public ActionResult AMenuUpdate(Menu m)
		{
			ValidationResult result = validationRules.Validate(m);
			if (result.IsValid)
			{
				m.Status = false;
				mm.MenuUpdate(m);
				return RedirectToAction("AMenuList");
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
		public ActionResult AMenuDoFalse(int id)
		{
			var idmenu = mm.GetByID(id);
			idmenu.Status = false;
			mm.MenuUpdate(idmenu);
			return RedirectToAction("AMenuList");
		}
		public ActionResult AMenuDoTrue(int id)
		{
			var idmenu = mm.GetByID(id);
			idmenu.Status = true;
			mm.MenuUpdate(idmenu);
			return RedirectToAction("AMenuList");
		}
		public ActionResult AMenuDelete(int id)
		{
			var idmenu = mm.GetByID(id);
			mm.MenuDelete(idmenu);
			return RedirectToAction("AMenuList");
		}
	}
}