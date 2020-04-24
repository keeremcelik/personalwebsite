using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entity;

namespace WebUI.Data.Abstract
{
    public interface IPostRepository
    {
        Post GetById(int postId);
        IQueryable<Post> GetAll();
        void AddPost(Post post);
        void DeletePost(int postId);
        void SavePost(Post post);
    }
}
