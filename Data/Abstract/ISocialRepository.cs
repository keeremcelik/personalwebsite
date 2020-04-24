using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entity;

namespace WebUI.Data.Abstract
{
    public interface ISocialRepository
    {
        SocialSetting GetById(int socialSettingId);
        IQueryable<SocialSetting> GetAll();
        void AddSiteSocialSetting(SocialSetting socialSetting);
        void DeleteSocialSetting(int socialSettingId);
        void SaveSocialSetting(SocialSetting socialSetting);
    }
}
