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
	public class FranchiseManager : IFranchiseService
	{
		IFranchiseDal _franchiseDal;

		public FranchiseManager(IFranchiseDal franchiseDal)
		{
			_franchiseDal = franchiseDal;
		}
		public void FranchiseAdd(Franchise franchise)
		{
			_franchiseDal.Add(franchise);
		}

		public void FranchiseDelete(Franchise franchise)
		{
			_franchiseDal.Delete(franchise);
		}

		public void FranchiseUpdate(Franchise franchise)
		{
			_franchiseDal.Update(franchise);
		}

		public List<Franchise> GetAll()
		{
			return _franchiseDal.GetAll();
		}

		public Franchise GetByID(int id)
		{
			return _franchiseDal.Get(x => x.FranID == id);
		}

		public List<Franchise> GetFranchiseByID(int id)
		{
			return _franchiseDal.GetAll(x => x.FranID == id);
		}

		public List<Franchise> GetOrderByDate()
		{
			return _franchiseDal.GetAll().OrderByDescending(z => z.DateFran).ToList();
		}
	}
}
