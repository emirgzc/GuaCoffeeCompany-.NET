using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IFranchiseService
	{
        List<Franchise> GetAll();
        List<Franchise> GetOrderByDate();
        List<Franchise> GetFranchiseByID(int id);
        Franchise GetByID(int id);
        void FranchiseAdd(Franchise franchise);
        void FranchiseUpdate(Franchise franchise);
        void FranchiseDelete(Franchise franchise);
    }
}
