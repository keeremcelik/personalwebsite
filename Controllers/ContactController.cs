using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data.Abstract;

namespace WebUI.Controllers
{
    public class ContactController : Controller
    {
        private IPersonalSettingRepository _personalRepository;
        private ISiteSettingRepository _siteSettingRepository;
        private ICategoryRepository _categoryRepository;
        private ISocialRepository _socialRepository;
        public ContactController(ISocialRepository socialRepo,ICategoryRepository categoryRepo,IPersonalSettingRepository personalRepo, ISiteSettingRepository siteSettingRepo)
        {
            _personalRepository = personalRepo;
            _siteSettingRepository = siteSettingRepo;
            _siteSettingRepository = siteSettingRepo;
            _categoryRepository = categoryRepo;
            _socialRepository = socialRepo;
        }
        public IActionResult Index()
        {
            ViewBag.personal = _personalRepository.GetById(1);
            ViewBag.site = _siteSettingRepository.GetById(1);
            ViewBag.social = _socialRepository.GetAll();
            ViewBag.category = _categoryRepository.GetAll();
            return View();
        }
    }
}