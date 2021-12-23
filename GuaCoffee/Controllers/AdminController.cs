﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using GuaCoffee.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GuaCoffee.Controllers
{
	public class AdminController : Controller
	{
		AdminManager adm = new AdminManager(new EfAdminDal());
		AdminValidator validationRules = new AdminValidator();
		Context c = new Context();
		public ActionResult Index()
		{
			var adlist = adm.GetAll();
			return View(adlist);
		}
		[HttpGet]
		public ActionResult AAddAdmin()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AAddAdmin(Admin a)
		{
			ValidationResult result = validationRules.Validate(a);

			if (result.IsValid)
			{
				string sifreli = Sifrele.MD5Olustur(a.Password);
				a.Password = sifreli;
				adm.AdminAdd(a);
				return RedirectToAction("Index");
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
		public ActionResult AAdminUpdate(int id)
		{
			var idad = adm.GetByID(id);
			return View(idad);
		}
		[HttpPost]
		public ActionResult AAdminUpdate(Admin a)
		{
			ValidationResult result = validationRules.Validate(a);

			if (a.Password == null)
			{
				if (result.IsValid)
				{
					var adpas = c.Admins.Where(x => x.AdminId == a.AdminId).Select(z => z.Password).FirstOrDefault();
					a.Password = adpas;
					adm.AdminUpdate(a);
					return RedirectToAction("Index");
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
			else
			{
				if (result.IsValid)
				{
					string sifreli = Sifrele.MD5Olustur(a.Password);
					a.Password = sifreli;
					adm.AdminUpdate(a);
					return RedirectToAction("Index");
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
		public ActionResult AAdminDelete(int id)
		{
			var idd = adm.GetByID(id);
			adm.AdminDelete(idd);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult AAdminProfile(int id = 0)
		{
			string p = (string)Session["Username"];
			id = c.Admins.Where(x => x.Username == p).Select(z => z.AdminId).FirstOrDefault();
			var adminid = adm.GetByID(id);
			return View(adminid);
		}
		[HttpPost]
		public ActionResult AAdminProfile(Admin a)
		{
			ValidationResult result = validationRules.Validate(a);

			if (a.Password == null)
			{
				if (result.IsValid)
				{
					string p = (string)Session["Username"];
					var adpas = c.Admins.Where(x => x.Username == p).Select(z => z.Password).FirstOrDefault();
					a.Password = adpas;
					adm.AdminUpdate(a);
					FormsAuthentication.SignOut();
					Session.Abandon();
					return RedirectToAction("Index", "AdminLogin");
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
			else
			{
				if (result.IsValid)
				{
					string p = (string)Session["Username"];
					string sifreli = Sifrele.MD5Olustur(a.Password);
					a.Password = sifreli;
					adm.AdminUpdate(a);
					FormsAuthentication.SignOut();
					Session.Abandon();
					return RedirectToAction("Index", "AdminLogin");
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
}