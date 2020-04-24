using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entity;

namespace WebUI.Data.Abstract
{
    public interface  IImageRepository
    {
        Image GetById(int imageId);
        IQueryable<Image> GetAll();
        void AddImage(string Name,int postId,int type);
        void DeleteImage(int imageId);
        void SaveImage(Image image);
        void ChangeCoverImage(int imageId);
    }
}
