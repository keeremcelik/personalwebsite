using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Data.Concrete.EfCore
{
    public class EfPostRepository : IPostRepository
    {
        private ApplicationIdentityDbContext _context;
        public EfPostRepository(ApplicationIdentityDbContext context)
        {
            _context = context;
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
        }

        public void DeletePost(int postId)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == postId);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }

        public IQueryable<Post> GetAll()
        {
            return _context.Posts;
        }

        public Post GetById(int postId)
        {
            return _context.Posts.FirstOrDefault(p => p.PostId==postId);
        }


        public void SavePost(Post post)
        {
            if (post.PostId == 0)
            {
                _context.Posts.Add(post);
            }
            else
            {
                var data = GetById(post.PostId);
                if (data != null)
                {
                    data.UserId = post.UserId;
                    data.CatId = post.CatId;
                    data.Title = post.Title;
                    data.SefUrl = post.SefUrl;
                    data.Abstract = post.Abstract;
                    data.Content = post.Content;
                    data.Keywords = post.Keywords;
                    data.CoverImage = post.CoverImage;
                    data.Image = post.Image;
                    data.Date = DateTime.Now;
                    data.Status = post.Status;
                }
            }
            _context.SaveChanges();
        }
    }
}