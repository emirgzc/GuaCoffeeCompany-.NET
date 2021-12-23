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
	public class SettingManager : ISettingService
	{
		ISettingDal _settingDal;

		public SettingManager(ISettingDal settingDal)
		{
			_settingDal = settingDal;
		}
		public List<Setting> GetAll()
		{
			return _settingDal.GetAll();
		}

		public Setting GetByID(int id)
		{
			return _settingDal.Get(x => x.SetID == id);
		}

		public List<Setting> GetSettingByID(int id)
		{
			return _settingDal.GetAll(x => x.SetID == id);
		}

		public void SettingAdd(Setting setting)
		{
			_settingDal.Add(setting);
		}

		public void SettingDelete(Setting setting)
		{
			_settingDal.Delete(setting);
		}

		public void SettingUpdate(Setting setting)
		{
			_settingDal.Update(setting);
		}
	}
}
