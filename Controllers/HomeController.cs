using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Data.Abstract;
using WebUI.Models;

namespace WebUI.Controllers
{

    public class HomeController : Controller
    {
        private ISocialRepository _socialRepository;
        private IAbilityRepository _abilityRepository;
        private IProjectRepository _projectRepository;
        private IPostRepository _postRepository;
        private IPersonalSettingRepository _personalSettingRepository;
        private ISiteSettingRepository _siteSettingRepository;
        private IImageRepository _imageRepository;
        public HomeController(IImageRepository imageRepo, ISiteSettingRepository siteSettingRepo, IPersonalSettingRepository personalSettingRepo, IPostRepository postRepo, ISocialRepository socialRepo, IAbilityRepository abilityRepo, IProjectRepository projectRepo)
        {
            _socialRepository = socialRepo;
            _abilityRepository = abilityRepo;
            _projectRepository = projectRepo;
            _postRepository = postRepo;
            _personalSettingRepository = personalSettingRepo;
            _siteSettingRepository = siteSettingRepo;
            _imageRepository = imageRepo;
        }
        public IActionResult Index()
        {
            ViewBag.social = _socialRepository.GetAll();
            ViewBag.ability = _abilityRepository.GetAll();
            ViewBag.project = _projectRepository.GetAll().Where(i => i.Status==true);
            ViewBag.post = _postRepository.GetAll().Take(4);
            ViewBag.personal = _personalSettingRepository.GetById(1);
            ViewBag.site = _siteSettingRepository.GetById(1);
            ViewBag.coverImage = _imageRepository.GetAll().Where(i => i.IsCoverImage == true);
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

