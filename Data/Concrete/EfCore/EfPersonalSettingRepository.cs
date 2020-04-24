using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Data.Concrete.EfCore
{
    public class EfPersonalSettingRepository : IPersonalSettingRepository
    {
        private ApplicationIdentityDbContext _context;
        public EfPersonalSettingRepository(ApplicationIdentityDbContext context)
        {
            _context = context;
        }

        public void AddPersonalSetting(PersonalSetting personalSetting)
        {
            _context.PersonalSettings.Add(personalSetting);
        }

        public void DeletePersonalSetting(int personalSettingId)
        {
            var personalSetting = _context.PersonalSettings.FirstOrDefault(c => c.PSId == personalSettingId);
            if (personalSetting != null)
            {
                _context.PersonalSettings.Remove(personalSetting);
                _context.SaveChanges();
            }
        }

        public IQueryable<PersonalSetting> GetAll()
        {
            return _context.PersonalSettings;
        }

        public PersonalSetting GetById(int personalSettingId)
        {
            return _context.PersonalSettings.FirstOrDefault(p => p.PSId==personalSettingId);
        }

        public void SavePersonalSetting(PersonalSetting personalSetting)
        {
            if (personalSetting.PSId == 0)
            {
                _context.PersonalSettings.Add(personalSetting);
            }
            else
            {
                var data = GetById(personalSetting.PSId);
                if (data != null)
                {
                    data.Name = personalSetting.Name;
                    data.Degree = personalSetting.Degree;
                    data.Email = personalSetting.Email;
                    data.Phone = personalSetting.Phone;
                    data.Address = personalSetting.Address;
                    data.Image = personalSetting.Image;
                    data.Status = personalSetting.Status;
                }
            }
            _context.SaveChanges();
        }
    }
}