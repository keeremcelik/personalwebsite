using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Data.Concrete.EfCore
{
    public class EfCommentRepository : ICommentRepository
    {
        private ApplicationIdentityDbContext _context;
        public EfCommentRepository(ApplicationIdentityDbContext context)
        {
            _context = context;
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void DeleteComment(int commentId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.CommentId==commentId);
            if (comment!= null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
        }

        public IQueryable<Comment> GetAll()
        {
            return _context.Comments;
        }

        public Comment GetById(int commentId)
        {
            return _context.Comments.First(c => c.CommentId==commentId);
        }

        public void SaveComment(Comment comment)
        {
            if (comment.CommentId == 0)
            {
                _context.Comments.Add(comment);
            }
            else
            {
                var data = GetById(comment.CommentId);
                if (data != null)
                {
                    data.Name = comment.Name;
                    data.PostId = comment.PostId;
                    data.Content = comment.Content;
                    data.Date = DateTime.Now;
                    data.Status = comment.Status;
                }
            }
            _context.SaveChanges();
        }
    }
}
