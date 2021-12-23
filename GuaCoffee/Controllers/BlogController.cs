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
	public class BlogController : Controller
	{
		BlogValidator validationRules = new BlogValidator();
		BlogManager bm = new BlogManager(new EfBlogDal());
		Context c = new Context();
		[AllowAnonymous]
		public ActionResult Index()
		{
			var blogList = bm.GetStatusTrue();
			return View(blogList);
		}
		[AllowAnonymous]
		public ActionResult BlogDetails(int id)
		{
			var blogidList = bm.GetBlogByID(id);
			return View(blogidList);
		}
		public ActionResult ABlogList()
		{
			var actidList = bm.GetOrderByDate();
			return View(actidList);
		}
		[HttpGet]
		public ActionResult ANewBlog()
		{
			return View();
		}
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult ANewBlog(Blog b)
		{
			ValidationResult result = validationRules.Validate(b);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);

			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 999999999).ToString() + uzanti;

			string way = "~/Image/Blog/" + filename;
			b.Image = "/Image/Blog/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						b.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
						b.Status = false;
						bm.BlogAdd(b);
						return RedirectToAction("ABlogList");
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
		public ActionResult ADeleteBlog(int id)
		{
			var idgal = bm.GetByID(id);
			var filename = Request.MapPath("~" + idgal.Image);
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			bm.BlogDelete(idgal);
			return RedirectToAction("ABlogList");
		}
		public ActionResult ABlogDoFalse(int id)
		{
			var idser = bm.GetByID(id);
			idser.Status = false;
			bm.BlogUpdate(idser);
			return RedirectToAction("ABlogList");
		}
		public ActionResult ABlogDoTrue(int id)
		{
			var idser = bm.GetByID(id);
			idser.Status = true;
			bm.BlogUpdate(idser);
			return RedirectToAction("ABlogList");
		}
		[HttpGet]
		public ActionResult ABlogUpdate(int id)
		{
			var idserv = bm.GetByID(id);
			return View(idserv);
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult ABlogUpdate(Blog b)
		{
			ValidationResult result = validationRules.Validate(b);

			string filename = Path.GetFileName(Request.Files[0].FileName);
			string uzanti = Path.GetExtension(Request.Files[0].FileName);

			Random rand = new Random();
			filename = DateTime.Now.ToShortDateString() + "-" + rand.Next(0, 999999999).ToString() + uzanti;

			string way = "~/Image/Blog/" + filename;
			b.Image = "/Image/Blog/" + filename;

			if (Request.Files.Count > 0)
			{
				if (uzanti.ToLower() == ".jpg" || uzanti.ToLower() == ".jpeg" || uzanti.ToLower() == ".png")
				{
					if (result.IsValid)
					{
						Request.Files[0].SaveAs(Server.MapPath(way));
						b.BlogDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
						b.Status = false;
						bm.BlogUpdate(b);
						return RedirectToAction("ABlogList");
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
					string resim = c.Blogs.Where(x => x.BlogID == b.BlogID).Select(z => z.Image).FirstOrDefault();
					b.Image = resim;
					b.Status = false;
					b.BlogDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
					bm.BlogUpdate(b);
					return RedirectToAction("ABlogList");
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