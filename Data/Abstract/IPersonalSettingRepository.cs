using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entity;

namespace WebUI.Data.Abstract
{
    public interface IPersonalSettingRepository
    {
        PersonalSetting GetById(int personalSettingId);
        IQueryable<PersonalSetting> GetAll();
        void AddPersonalSetting(PersonalSetting personalSetting);
        void DeletePersonalSetting(int personalSettingId);
        void SavePersonalSetting(PersonalSetting personalSetting);
    }
}
