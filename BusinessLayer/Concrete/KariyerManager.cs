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
	public class KariyerManager : IKariyerService
	{
		IKariyerDal _kariyerDal;

		public KariyerManager(IKariyerDal kariyerDal)
		{
			_kariyerDal = kariyerDal;
		}
		public void KariyerAdd(Kariyer kariyer)
		{
			_kariyerDal.Add(kariyer);
		}

		public void KariyerDelete(Kariyer kariyer)
		{
			_kariyerDal.Delete(kariyer);
		}

		public void KariyerUpdate(Kariyer kariyer)
		{
			_kariyerDal.Update(kariyer);
		}

		public List<Kariyer> GetAll()
		{
			return _kariyerDal.GetAll();
		}

		public Kariyer GetByID(int id)
		{
			return _kariyerDal.Get(x => x.KarID == id);
		}

		public List<Kariyer> GetKariyerByID(int id)
		{
			return _kariyerDal.GetAll(x => x.KarID == id);
		}

		public List<Kariyer> GetOrderByDate()
		{
			return _kariyerDal.GetAll().OrderByDescending(z => z.DateKar).ToList();
		}
	}
}
