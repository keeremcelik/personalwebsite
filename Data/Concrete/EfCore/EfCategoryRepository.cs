using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data.Abstract;
using WebUI.Entity;

namespace WebUI.Data.Concrete.EfCore
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private ApplicationIdentityDbContext _context;
        public EfCategoryRepository(ApplicationIdentityDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category GetById(int categoryId)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId==categoryId);
        }

        public void SaveCategory(Category category)
        {
            if (category.CategoryId == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                var data = GetById(category.CategoryId);
                if (category != null)
                {
                    data.Name = category.Name;
                    data.Keywords = category.Keywords;
                    data.Descriptions = category.Descriptions;
                    data.Date = DateTime.Now;
                    data.Status = data.Status;
                }
            }
            _context.SaveChanges();
        }
    }
}
