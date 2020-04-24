using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Controllers
{
    public class PostController : Controller
    {
        private IPostRepository _postRepository;
        private ICategoryRepository _categoryRepository;
        private IImageRepository _imageRepository;
        public PostController(IPostRepository postRepo, ICategoryRepository catRepo, IImageRepository imgRepo)
        {
            _postRepository = postRepo;
            _categoryRepository = catRepo;
            _imageRepository = imgRepo;
        }

        public IActionResult CoverImage(int id)
        {
            _imageRepository.ChangeCoverImage(id);
            var postId = _imageRepository.GetById(id).PostId;
            return RedirectToAction("Edit", new { id = postId });
        }
        [Route("panel/post")]
        public IActionResult Index()
        {
            var data = _postRepository.GetAll();
            return View(data);
        }
        [Route("panel/post/edit")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _postRepository.GetById(id);
            ViewBag.images = _imageRepository.GetAll().Where(i => i.PostId == id).Where(i => i.Type == 1);
            pullSelect();
            return View(data);
        }
        [Route("panel/post/edit")]
        [HttpPost]
        public async Task<IActionResult> Edit(Post post, IFormFile[] file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var p = "wwwroot\\img\\posts\\" + post.PostId;
                    foreach (var f in file)
                    {
                        if (f != null)
                        {
                            string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(f.FileName);
                            var path = Path.Combine(Directory.GetCurrentDirectory(), p, ImageName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await f.CopyToAsync(stream);
                                _imageRepository.AddImage(ImageName, post.PostId, 1);
                            }
                        }
                    }
                }
                _postRepository.SavePost(post);
                return RedirectToAction("Index");
            }
            pullSelect();
            return View(post);
        }

        public void pullSelect()
        {
            ViewBag.Category = new SelectList(_categoryRepository.GetAll(), "CategoryId", "Name");
        }
        [HttpGet]
        [Route("panel/post/delete")]
        public IActionResult Delete(int id)
        {
            return View(_postRepository.GetById(id));
        }
        [Route("panel/post/delete")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int PostId)
        {
            _postRepository.DeletePost(PostId);
            return RedirectToAction("Index");
        }

        [Route("panel/post/deleteimage")]
        [HttpGet]
        public IActionResult DeleteImg(int id)
        {
            var postId = _imageRepository.GetById(id).PostId;
            _imageRepository.DeleteImage(id);
            return RedirectToAction("Edit", new { id = postId });
        }

        [Route("panel/post/create")]
        [HttpGet]
        public IActionResult Create()
        {
            pullSelect();
            return View();
        }
        [HttpPost]
        [Route("panel/post/create")]
        public async Task<IActionResult> Create(Post entity, IFormFile[] file)
        {

            if (ModelState.IsValid)
            {
                int max = _postRepository.GetAll().Max(i => i.PostId);
                var p = "wwwroot\\img\\posts\\" + (max + 1);
                if (!Directory.Exists(p))
                {
                    Directory.CreateDirectory(p);
                }
                int x = file.Length;
                foreach (var f in file)
                {
                    if (f != null)
                    {
                       
                        string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(f.FileName);
                        var path = Path.Combine(Directory.GetCurrentDirectory(), p, ImageName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await f.CopyToAsync(stream);
                            _imageRepository.AddImage(ImageName, (max + 1), 1);
                        }
                    }
                }
                _postRepository.SavePost(entity);

                return RedirectToAction("Index");
            }
            pullSelect();
            return View(entity);
        }
    }
}