using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Data.Concrete.EfCore
{
    public class EfSiteSettingRepository : ISiteSettingRepository
    {
        private ApplicationIdentityDbContext _context;
        public EfSiteSettingRepository(ApplicationIdentityDbContext context)
        {
            _context = context;
        }

        public void AddSiteSetting(SiteSetting siteSetting)
        {
            _context.SiteSettings.Add(siteSetting);
        }

        public void DeleteSiteSetting(int siteSettingId)
        {
            var siteSetting = _context.SiteSettings.FirstOrDefault(s => s.SSId==siteSettingId);
            if (siteSetting != null)
            {
                _context.SiteSettings.Remove(siteSetting);
                _context.SaveChanges();
            }
        }

        public IQueryable<SiteSetting> GetAll()
        {
            return _context.SiteSettings;
        }

        public SiteSetting GetById(int siteSettingId)
        {
            return _context.SiteSettings.FirstOrDefault(s => s.SSId==siteSettingId);
        }

        public void SaveSiteSetting(SiteSetting siteSetting)
        {
            if (siteSetting.SSId == 0)
            {
                _context.SiteSettings.Add(siteSetting);
            }
            else
            {
                var data = GetById(siteSetting.SSId);
                if (data != null)
                {
                    data.SiteName = siteSetting.SiteName;
                    data.Title = siteSetting.Title;
                    data.Description = siteSetting.Description;
                    data.GoogleID = siteSetting.GoogleID;
                    data.GoogleCode = siteSetting.GoogleCode;
                    data.GoogleMap = siteSetting.GoogleMap;
                    data.Status = siteSetting.Status;
                }
            }
            _context.SaveChanges();
        }
    }
}