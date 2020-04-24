using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entity;

namespace WebUI.Data.Abstract
{
    public interface ICommentRepository
    {
        Comment GetById(int commentId);
        IQueryable<Comment> GetAll();
        void AddComment(Comment comment);
        void DeleteComment(int commentId);
        void SaveComment(Comment comment);
    }
}
