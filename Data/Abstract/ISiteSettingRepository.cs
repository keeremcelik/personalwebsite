using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entity;

namespace WebUI.Data.Abstract
{
    public interface ISiteSettingRepository
    {
        SiteSetting GetById(int siteSettingId);
        IQueryable<SiteSetting> GetAll();
        void AddSiteSetting(SiteSetting siteSetting);
        void DeleteSiteSetting(int siteSettingId);
        void SaveSiteSetting(SiteSetting siteSetting);
    }
}
