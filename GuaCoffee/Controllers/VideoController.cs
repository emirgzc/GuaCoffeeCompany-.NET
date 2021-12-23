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
	public class VideoController : Controller
	{
		VideoValidator validationRules = new VideoValidator();
		VideoManager vm = new VideoManager(new EfVideoDal());
		[AllowAnonymous]
		public ActionResult Index()
		{
			var videoList = vm.GetListStatusTrue();
			return View(videoList);
		}
		public ActionResult AVideoList()
		{
			var video = vm.GetOrderByDate();
			return View(video);
		}
		[HttpGet]
		public ActionResult AVideoAdd()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AVideoAdd(Video g)
		{
			ValidationResult results = validationRules.Validate(g);

			if (results.IsValid)
			{
				g.Status = true;
				g.DateVideo = DateTime.Parse(DateTime.Now.ToLongTimeString());
				vm.VideoAdd(g);
				return RedirectToAction("AVideoList");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}

			return View();
		}
		public ActionResult AVideoDelete(int id)
		{
			var idmenu = vm.GetByID(id);
			vm.VideoDelete(idmenu);
			return RedirectToAction("AVideoList");
		}
		public ActionResult AVideoDoFalse(int id)
		{
			var idser = vm.GetByID(id);
			idser.Status = false;
			vm.VideoUpdate(idser);
			return RedirectToAction("AVideoList");
		}
		public ActionResult AVideoDoTrue(int id)
		{
			var idser = vm.GetByID(id);
			idser.Status = true;
			vm.VideoUpdate(idser);
			return RedirectToAction("AVideoList");
		}
	}
}