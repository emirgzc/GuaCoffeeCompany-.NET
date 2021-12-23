using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IStoreService
	{
        List<Store> GetAll();
        List<Store> GetListStatusTrue();
        List<Store> GetOrderByDate();
        List<Store> GetStoreByID(int id);
        Store GetByID(int id);
        void StoreAdd(Store store);
        void StoreUpdate(Store store);
        void StoreDelete(Store store);
    }
}
