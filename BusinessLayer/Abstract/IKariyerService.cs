using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IKariyerService
	{
        List<Kariyer> GetAll();
        List<Kariyer> GetOrderByDate();
        List<Kariyer> GetKariyerByID(int id);
        Kariyer GetByID(int id);
        void KariyerAdd(Kariyer kariyer);
        void KariyerUpdate(Kariyer kariyer);
        void KariyerDelete(Kariyer kariyer);
    }
}
