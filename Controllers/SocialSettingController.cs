using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Controllers
{
    public class SocialSettingController : Controller
    {
        private ISocialRepository _socialRepository;
        public SocialSettingController(ISocialRepository socialRepo)
        {
            _socialRepository = socialRepo;
        }
        [Route("panel/setting/social")]
        public IActionResult Index()
        {
            return View(_socialRepository.GetAll());
        }
        [Route("panel/setting/social/edit")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _socialRepository.GetById(id);
            return View(data);
        }
        [Route("panel/setting/social/edit")]
        [HttpPost]
        public IActionResult Edit(SocialSetting social)
        {
            if (ModelState.IsValid)
            {
                _socialRepository.SaveSocialSetting(social);
                return RedirectToAction("Index");
            }
            return View(social);
        }
        [Route("panel/setting/social/delete")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_socialRepository.GetById(id));
        }
        [Route("panel/setting/social/delete")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int SocialId)
        {
            _socialRepository.DeleteSocialSetting(SocialId);
            return RedirectToAction("Index");
        }
        [Route("panel/setting/social/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Route("panel/setting/social/create")]
        [HttpPost]
        public IActionResult Create(SocialSetting entity)
        {
            if (ModelState.IsValid)
            {
                _socialRepository.SaveSocialSetting(entity);
                return RedirectToAction("Index");
            }
            return View(entity);
        }

    }
}