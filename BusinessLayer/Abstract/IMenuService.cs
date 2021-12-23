using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IMenuService
	{
        List<Menu> GetAll();
        List<Menu> GetStatusByTrue();
        List<Menu> GetMenuByID(int id);
        Menu GetByID(int id);
        void MenuAdd(Menu menu);
        void MenuUpdate(Menu menu);
        void MenuDelete(Menu menu);
    }
}
