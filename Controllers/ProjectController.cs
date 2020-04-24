using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepository _projectRepository;
        private IImageRepository _imageRepository;
        public ProjectController(IProjectRepository projectRepo, IImageRepository imageRepo)
        {
            _projectRepository = projectRepo;
            _imageRepository = imageRepo;

        }
        [Route("panel/project")]
        public IActionResult Index()
        {
            return View(_projectRepository.GetAll());
        }
        [Route("panel/project/edit")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _projectRepository.GetById(id);
            ViewBag.images = _imageRepository.GetAll().Where(i => i.PostId == id).Where(i => i.Type==2);
            return View(data);
        }
        [Route("panel/project/edit")]
        [HttpPost]
        public async Task<IActionResult> Edit(Project project, IFormFile[] file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var p = "wwwroot\\img\\projects\\" + project.ProjectId;
                    foreach (var f in file)
                    {
                        if (f != null)
                        {
                            string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(f.FileName);
                            var path = Path.Combine(Directory.GetCurrentDirectory(), p, ImageName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await f.CopyToAsync(stream);
                                _imageRepository.AddImage(ImageName, project.ProjectId, 2);
                            }
                        }
                    }
                }
                _projectRepository.SaveProject(project);
                return RedirectToAction("Index");
            }
            return View(project);
        }
        [Route("panel/project/delete")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_projectRepository.GetById(id));
        }
        [Route("panel/project/delete")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int ProjectId)
        {
            _projectRepository.DeleteProject(ProjectId);
            return RedirectToAction("Index");
        }
        [Route("panel/project/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Route("panel/project/create")]
        [HttpPost]
        public async Task<IActionResult> Create(Project entity, IFormFile[] file)
        {
            if (ModelState.IsValid)
            {
                int max = _projectRepository.GetAll().Max(i => i.ProjectId);
                var p = "wwwroot\\img\\projects\\" + (max + 1);
                if (!Directory.Exists(p))
                {
                    Directory.CreateDirectory(p);
                }
                foreach (var f in file)
                {
                    if (f != null)
                    {
                        string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(f.FileName);
                        var path = Path.Combine(Directory.GetCurrentDirectory(), p, ImageName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await f.CopyToAsync(stream);
                            _imageRepository.AddImage(ImageName, (max + 1),2);
                        }
                    }
                }
                _projectRepository.SaveProject(entity);

                return RedirectToAction("Index");
            }
           
            return View(entity);
        }

    }
}