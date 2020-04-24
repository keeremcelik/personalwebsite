using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Data.Concrete.EfCore
{
    public class EfAbilityRepository : IAbilityRepository
    {
        private ApplicationIdentityDbContext _context;
        public EfAbilityRepository(ApplicationIdentityDbContext context)
        {
            _context = context;
        }

        public void AddAbility(Ability ability)
        {
            _context.Abilities.Add(ability);
        }

        public void DeleteAbility(int abilityId)
        {
            var ability = _context.Abilities.FirstOrDefault(i => i.AbilityId == abilityId);

            if (ability != null)
            {
                _context.Abilities.Remove(ability);
                _context.SaveChanges();
            }
        }

        public IQueryable<Ability> GetAll()
        {
            return _context.Abilities;
        }

        public Ability GetById(int abilityId)
        {
            return _context.Abilities.FirstOrDefault(i => i.AbilityId == abilityId);
        }

        public void SaveAbility(Ability ability)
        {
            if (ability.AbilityId == 0)
            {
                _context.Abilities.Add(ability);
            }
            else
            {
                var data = GetById(ability.AbilityId);
                if (data != null)
                {
                    data.Name = ability.Name;
                    data.Rate = ability.Rate;
                    data.Status = ability.Status;
                }
            }
            _context.SaveChanges();
        }
    }
}
