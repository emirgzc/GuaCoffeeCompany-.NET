using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context : DbContext
	{
		public DbSet<About> Abouts { get; set; }
		public DbSet<Admin>  Admins { get; set; }
		public DbSet<Activity> Activities { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Franchise> Franchises { get; set; }
		public DbSet<Galery> Galeries { get; set; }
		public DbSet<Kariyer> Kariyers { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Setting> Settings { get; set; }
		public DbSet<Slider> Sliders { get; set; }
		public DbSet<Store> Stores { get; set; }
		public DbSet<Sube> Subes { get; set; }
		public DbSet<Video> Videos { get; set; }
	}
}
