using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Controllers
{
    [Authorize]
  
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepository = categoryRepo;
        }
        [Route("panel/category")]
        public IActionResult Index()
        {
            return View(_categoryRepository.GetAll());
        }
        [HttpGet]
        [Route("panel/category/edit")]
        public IActionResult Edit(int id)
        {
            var data = _categoryRepository.GetById(id);
            return View(data);
        }
        [HttpPost]
        [Route("panel/category/edit")]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.SaveCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        [Route("panel/category/delete")]
        public IActionResult Delete(int id)
        {
            return View(_categoryRepository.GetById(id));
        }
        [Route("panel/category/delete")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int CategoryId)
        {
            _categoryRepository.DeleteCategory(CategoryId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("panel/category/create")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("panel/category/create")]
        [HttpPost]
        public IActionResult Create(Category entity)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.SaveCategory(entity);
                return RedirectToAction("Index");
            }
            return View(entity);
        }

    }
}