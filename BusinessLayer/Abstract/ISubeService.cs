using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ISubeService
	{
        List<Sube> GetAll();
        List<Sube> GetListStatusTrue();
        List<Sube> GetSubeByID(int id);
        Sube GetByID(int id);
        void SubeAdd(Sube sube);
        void SubeUpdate(Sube sube);
        void SubeDelete(Sube sube);
    }
}
