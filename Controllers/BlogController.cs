using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data.Abstract;
using WebUI.Entity;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        private ISocialRepository _socialRepository;
        private IAbilityRepository _abilityRepository;
        private IProjectRepository _projectRepository;
        private IPostRepository _postRepository;
        private IPersonalSettingRepository _personalSettingRepository;
        private ISiteSettingRepository _siteSettingRepository;
        private ICategoryRepository _categoryRepository;
        private IImageRepository _imageRepository;
        private ICommentRepository _commentRepository;
        public BlogController(ICommentRepository commentRepo, IImageRepository imageRepo, ICategoryRepository categoryRepo, ISiteSettingRepository siteSettingRepo, IPersonalSettingRepository personalSettingRepo, IPostRepository postRepo, ISocialRepository socialRepo, IAbilityRepository abilityRepo, IProjectRepository projectRepo)
        {
            _categoryRepository = categoryRepo;
            _socialRepository = socialRepo;
            _abilityRepository = abilityRepo;
            _projectRepository = projectRepo;
            _postRepository = postRepo;
            _personalSettingRepository = personalSettingRepo;
            _siteSettingRepository = siteSettingRepo;
            _imageRepository = imageRepo;
            _commentRepository = commentRepo;
        }
        public IActionResult Index()
        {
            LayoutViewBags();
            ViewBag.ability = _abilityRepository.GetAll().Where(i => i.Status == true);
            ViewBag.project = _projectRepository.GetAll().Where(i => i.Status == true);
            ViewBag.post = _postRepository.GetAll().Take(10).Where(i => i.Status == true);

            ViewBag.CoverImage = _imageRepository.GetAll().Where(i => i.IsCoverImage == true);
            return View();
        }
        [HttpGet]
        public IActionResult DetailPost(int id)
        {
            var post = _postRepository.GetById(id);

            LayoutViewBags();
            ViewBag.image = _imageRepository.GetAll().Where(i => i.PostId == id).Where(i => i.Type == 1);
            ViewBag.CoverImage = _imageRepository.GetAll().Where(i => i.IsCoverImage == true).Where(i => i.Type == 1).FirstOrDefault(i => i.PostId == id);
            ViewBag.comments = _commentRepository.GetAll().Where(i => i.PostId == id);
            return View(post);
        }
        [HttpPost]
        public IActionResult Send(int Postid, string Name, string Message)
        {
            Comment comment = new Comment();
            comment.PostId = Postid;
            comment.Name = Name;
            comment.Content = Message;
            comment.Date = DateTime.Now;
            comment.Status = true;
            _commentRepository.AddComment(comment);
            return RedirectToAction("detailpost", new { id = Postid });
        }
        public void LayoutViewBags()
        {
            ViewBag.personal = _personalSettingRepository.GetById(1);
            ViewBag.site = _siteSettingRepository.GetById(1);
            ViewBag.social = _socialRepository.GetAll();
            ViewBag.category = _categoryRepository.GetAll();
        }
        [Route("blog/projects")]
        public IActionResult Projects()
        {
            LayoutViewBags();
            ViewBag.CoverImage = _imageRepository.GetAll().Where(i => i.IsCoverImage == true);

            var projects = _projectRepository.GetAll().Where(i => i.Status == true);
            return View(projects);
        }
        [Route("blog/categories")]
        public IActionResult Categories(int id)
        {
            ViewBag.CoverImage = _imageRepository.GetAll().Where(i => i.IsCoverImage == true);
            var model = _postRepository.GetAll().Where(i => i.CatId == id);
            LayoutViewBags();
            return View(model);
        }
        [Route("blog/project/detail")]
        public IActionResult DetailProject(int id)
        {
            var project = _projectRepository.GetById(id);

            LayoutViewBags();
            ViewBag.image = _imageRepository.GetAll().Where(i => i.PostId == id).Where(i => i.Type == 2);
            ViewBag.CoverImage = _imageRepository.GetAll().Where(i => i.IsCoverImage == true).Where(i => i.Type == 2).FirstOrDefault(i => i.PostId == id);

            return View(project);
        }
    }
}