using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Controllers
{
    public class PersonalSettingController : Controller
    {
        private IPersonalSettingRepository _personalSettingRepository;
        public PersonalSettingController(IPersonalSettingRepository personalSettingRepo)
        {
            _personalSettingRepository = personalSettingRepo;
        }
        [Route("panel/setting/personal")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(_personalSettingRepository.GetById(1));
        }
        [Route("panel/setting/personal")]
        [HttpPost]
        public IActionResult Index(PersonalSetting personal)
        {
            if (ModelState.IsValid)
            {
                _personalSettingRepository.SavePersonalSetting(personal);
                return RedirectToAction("Index");
            }
            return View(personal);
        }
    }
}