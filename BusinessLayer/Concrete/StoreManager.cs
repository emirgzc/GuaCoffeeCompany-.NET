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
	public class StoreManager : IStoreService
	{
		IStoreDal _storeDal;

		public StoreManager(IStoreDal storeDal)
		{
			_storeDal = storeDal;
		}

		public void StoreAdd(Store store)
		{
			_storeDal.Add(store);
		}

		public void StoreDelete(Store store)
		{
			_storeDal.Delete(store);
		}

		public void StoreUpdate(Store store)
		{
			_storeDal.Update(store);
		}

		public List<Store> GetAll()
		{
			return _storeDal.GetAll();
		}

		public Store GetByID(int id)
		{
			return _storeDal.Get(x => x.StoreID == id);
		}

		public List<Store> GetStoreByID(int id)
		{
			return _storeDal.GetAll(x => x.StoreID == id);
		}

		public List<Store> GetListStatusTrue()
		{
			return _storeDal.GetAll(x => x.Status == true).OrderByDescending(z=>z.DateStore).ToList();
		}

		public List<Store> GetOrderByDate()
		{
			return _storeDal.GetAll().OrderByDescending(z => z.DateStore).ToList();
		}
	}
}
