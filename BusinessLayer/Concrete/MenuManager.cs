using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class MenuManager : IMenuService
	{
		IMenuDal _menuDal;

		public MenuManager(IMenuDal menuDal)
		{
			_menuDal = menuDal;
		}

		public List<Menu> GetAll()
		{
			return _menuDal.GetAll();
		}

		public Menu GetByID(int id)
		{
			return _menuDal.Get(x=>x.MenuID==id);
		}

		public List<Menu> GetMenuByID(int id)
		{
			return _menuDal.GetAll(x=>x.MenuID==id);
		}

		public List<Menu> GetStatusByTrue()
		{
			return _menuDal.GetAll(x=>x.Status==true);
		}

		public void MenuAdd(Menu menu)
		{
			_menuDal.Add(menu);
		}

		public void MenuDelete(Menu menu)
		{
			_menuDal.Delete(menu);
		}

		public void MenuUpdate(Menu menu)
		{
			_menuDal.Update(menu);
		}
	}
}
