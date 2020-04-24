using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Controllers
{
    public class SiteSettingController : Controller
    {
        private ISiteSettingRepository _siteSettingRepository;
        public SiteSettingController(ISiteSettingRepository siteSettingRepo)
        {
            _siteSettingRepository = siteSettingRepo;
        }
        [Route("panel/setting/site")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(_siteSettingRepository.GetById(1));
        }
        [Route("panel/setting/site")]
        [HttpPost]
        public IActionResult Index(SiteSetting entity)
        {
            if (ModelState.IsValid)
            {
                _siteSettingRepository.SaveSiteSetting(entity);
                return RedirectToAction("Index");
            }
            return View(entity);
        }
    }
}