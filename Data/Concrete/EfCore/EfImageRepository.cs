using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Data.Concrete.EfCore
{
    public class EfImageRepository : IImageRepository
    {
        private ApplicationIdentityDbContext _context;
        public EfImageRepository(ApplicationIdentityDbContext context)
        {
            _context = context;
        }

        public void AddImage(string Name, int postId, int type)
        {
            bool cover = false;
            if (GetAll().Where(i => i.PostId == postId).ToList().Count == 0)
            {
                cover = true;
            }
            var images = new Image()
            {
                Name = Name,
                IsCoverImage = cover,
                PostId = postId,
                Type = type,
                Status = true
            };
            _context.Add(images);
            _context.SaveChanges();
        }

        public void ChangeCoverImage(int imageId)
        {
            var coverImage = GetById(imageId);
            int type = GetById(imageId).Type;
            var images = GetAll().Where(i => i.PostId == coverImage.PostId).Where(i => i.Type == type);
            foreach (var img in images)
            {
                img.IsCoverImage = false;
            }

            if (coverImage != null)
            {
                coverImage.IsCoverImage = true;
            }
            _context.SaveChanges();

        }

        public void DeleteImage(int imageId)
        {
            var image = _context.Images.FirstOrDefault(i => i.ImageId == imageId);

            if (image != null)
            {
                _context.Images.Remove(image);
                _context.SaveChanges();
            }
        }

        public IQueryable<Image> GetAll()
        {
            return _context.Images;
        }

        public Image GetById(int imageId)
        {
            return _context.Images.FirstOrDefault(i => i.ImageId == imageId);
        }

        public void SaveImage(Image image)
        {
            if (image.ImageId == 0)
            {
                _context.Images.Add(image);
            }
            else
            {
                var data = GetById(image.ImageId);
                if (data != null)
                {
                    data.Name = image.Name;
                    data.IsCoverImage = image.IsCoverImage;
                    data.Status = image.Status;
                }
            }
            _context.SaveChanges();
        }
    }
}
