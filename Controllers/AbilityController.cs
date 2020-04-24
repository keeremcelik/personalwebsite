using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Controllers
{
    [Authorize]
    public class AbilityController : Controller
    {
        private IAbilityRepository _abilityRepository;
        public AbilityController(IAbilityRepository abilityRepository)
        {
            _abilityRepository = abilityRepository;
        }
        [Route("panel/ability")]
        public IActionResult Index()
        {
            var data = _abilityRepository.GetAll();
            return View(data);
        }
        [Route("panel/ability/edit")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _abilityRepository.GetById(id);
            return View(data);
        }
        [Route("panel/ability/edit")]
        [HttpPost]
        public IActionResult Edit(Ability ability)
        {
            if (ModelState.IsValid)
            {               
                _abilityRepository.SaveAbility(ability);
                return RedirectToAction("Index");
            }
            return View(ability);
        }
        [Route("panel/ability/delete")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_abilityRepository.GetById(id));
        }
        [Route("panel/ability/delete")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int AbilityId)
        {
            _abilityRepository.DeleteAbility(AbilityId);
            return RedirectToAction("Index");
        }
        [Route("panel/ability/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Route("panel/ability/create")]
        [HttpPost]
        public IActionResult Create(Ability entity)
        {
            if (ModelState.IsValid)
            {
                _abilityRepository.SaveAbility(entity);
                return RedirectToAction("Index");
            }
            return View(entity);
        }

    }
}