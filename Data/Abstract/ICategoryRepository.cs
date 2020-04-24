using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entity;

namespace WebUI.Data.Abstract
{
    public interface ICategoryRepository
    {
        Category GetById(int categoryId);
        IQueryable<Category> GetAll();
        void AddCategory(Category category);
        void DeleteCategory(int categoryId);
        void SaveCategory(Category category);
    }
}
