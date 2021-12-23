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
	public class SubeManager : ISubeService
	{
		ISubeDal _subeDal;

		public SubeManager(ISubeDal subeDal)
		{
			_subeDal = subeDal;
		}

		public void SubeAdd(Sube sube)
		{
			_subeDal.Add(sube);
		}

		public void SubeDelete(Sube sube)
		{
			_subeDal.Delete(sube);
		}

		public void SubeUpdate(Sube sube)
		{
			_subeDal.Update(sube);
		}

		public List<Sube> GetAll()
		{
			return _subeDal.GetAll();
		}

		public Sube GetByID(int id)
		{
			return _subeDal.Get(x => x.SubeID == id);
		}

		public List<Sube> GetSubeByID(int id)
		{
			return _subeDal.GetAll(x => x.SubeID == id);
		}

		public List<Sube> GetListStatusTrue()
		{
			return _subeDal.GetAll(x => x.Status == true);
		}
	}
}
