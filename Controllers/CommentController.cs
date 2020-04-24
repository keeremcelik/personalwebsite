using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Controllers
{
    public class CommentController : Controller
    {
        private ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepository = commentRepo;
        }
        [Route("panel/comment")]
        public IActionResult Index()
        {
            return View(_commentRepository.GetAll());
        }
        [Route("panel/comment/delete")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_commentRepository.GetById(id));
        }
        [Route("panel/comment/delete")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int CommentId)
        {
            _commentRepository.DeleteComment(CommentId);
            return RedirectToAction("Index");
        }
    
    

    }
}