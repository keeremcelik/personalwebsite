using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entity;
namespace WebUI.Data.Abstract
{
    public interface IAbilityRepository
    {
        Ability GetById(int abilityId);
        IQueryable<Ability> GetAll();
        void AddAbility(Ability ability);
        void DeleteAbility(int abilityId);
        void SaveAbility(Ability ability);
    }
}
