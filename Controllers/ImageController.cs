using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data.Abstract;

namespace WebUI.Controllers
{
    public class ImageController : Controller
    {
        private IImageRepository _imageRepository;
        public ImageController(IImageRepository imgRepo)
        {
            _imageRepository = imgRepo;
        }
        public IActionResult CoverImage(int id)
        {
            _imageRepository.ChangeCoverImage(id);
            var postId = _imageRepository.GetById(id).PostId;
            var typeId = _imageRepository.GetById(id).Type;
            string type = "";
            if (typeId == 1)
                type = "Post";
            else if (typeId == 2)
                type = "Project";

            return RedirectToAction("Edit", type, new { id = postId });
        }
        [HttpGet]
        public IActionResult DeleteImg(int id)
        {
            var postId = _imageRepository.GetById(id).PostId;
            var typeId = _imageRepository.GetById(id).Type;
            _imageRepository.DeleteImage(id);

            string type = "";
            if (typeId == 1)
                type = "Post";
            else if (typeId == 2)
                type = "Project";
            return RedirectToAction("Edit", type, new { id = postId });


        }
    }
}