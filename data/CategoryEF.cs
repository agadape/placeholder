using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_API.models;

namespace Simple_API.data
{
    public class CategoryEF : InterfaceCategory
    {
        //ef context
        private readonly ApplicationDBContext _context;
        public CategoryEF(ApplicationDBContext context)
        {
            _context = context;
        }
        public Category AddCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding category", ex);
            }
        }

        public void DeleteCategory(int id)
        {
            var existingCategory = GetCategory(id);
            if (existingCategory == null)
            {
                throw new Exception("Category not found");
            }
            try
            {
                _context.Categories.Remove(existingCategory);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting category", ex);
            }
        }

        public List<Category> GetCategories()
        {
            var categories = _context.Categories.OrderByDescending(c => c.CategoryName).ToList();
            return categories;
        }

        public Category GetCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            var existingCategory = GetCategory(category.CategoryId);
            if (existingCategory == null)
            {
                throw new Exception("Category not found");
            }
            try
            {
                existingCategory.CategoryId = category.CategoryId;
                existingCategory.CategoryName = category.CategoryName;
                _context.SaveChanges();
                return existingCategory;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating category", ex);
            }

        }
    }
}