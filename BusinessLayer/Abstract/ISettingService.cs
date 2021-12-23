using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ISettingService
	{
        List<Setting> GetAll();
        List<Setting> GetSettingByID(int id);
        Setting GetByID(int id);
        void SettingAdd(Setting setting);
        void SettingUpdate(Setting setting);
        void SettingDelete(Setting setting);
    }
}
