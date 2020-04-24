using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Data.Concrete.EfCore
{
    public class EfSocialRepository : ISocialRepository
    {
        private ApplicationIdentityDbContext _context;
        public EfSocialRepository(ApplicationIdentityDbContext context)
        {
            _context = context;
        }

        public void AddSiteSocialSetting(SocialSetting socialSetting)
        {
            _context.SocialSettings.Add(socialSetting);
        }

        public void DeleteSocialSetting(int socialSettingId)
        {
            var social = _context.SocialSettings.FirstOrDefault(s => s.SocialId==socialSettingId);
            if (social != null)
            {
                _context.SocialSettings.Remove(social);
                _context.SaveChanges();
            }
        }

        public IQueryable<SocialSetting> GetAll()
        {
            return _context.SocialSettings;
        }

        public SocialSetting GetById(int socialSettingId)
        {
            return _context.SocialSettings.FirstOrDefault(s => s.SocialId==socialSettingId);
        }

        public void SaveSocialSetting(SocialSetting socialSetting)
        {
            if (socialSetting.SocialId == 0)
            {
                _context.SocialSettings.Add(socialSetting);
            }
            else
            {
                var data = GetById(socialSetting.SocialId);
                if (data != null)
                {
                    data.Name = socialSetting.Name;
                    data.Icon = socialSetting.Icon;
                    data.Link = socialSetting.Link;
                    data.Status = socialSetting.Status;
                }
            }
            _context.SaveChanges();
        }
    }
}