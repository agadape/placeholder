using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_API.models;

namespace Simple_API.data
{
    public class CategoryDataAccesslayer_DAL : InterfaceCategory
    {
        private List<Category> _categories = new List<Category>();
        public CategoryDataAccesslayer_DAL()
        {
            _categories.Add(new Category { CategoryId = 1, CategoryName = "ASP. NET Core" });
            _categories.Add(new Category { CategoryId = 2, CategoryName = "ASP. NET MVC" });
            _categories.Add(new Category { CategoryId = 3, CategoryName = "Windows Forms" });
            _categories.Add(new Category { CategoryId = 4, CategoryName = "WPF" });
            _categories.Add(new Category { CategoryId = 5, CategoryName = "SQL Server" });
            _categories.Add(new Category { CategoryId = 6, CategoryName = "C#" });
        }
        public List<Category> GetCategories()
        {
            return _categories;
        }

        public Category GetCategory(int id)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            return category;
        }

        public Category AddCategory(Category category)
        {
            _categories.Add(category);
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategory(category.CategoryId);
            categoryToUpdate.CategoryName = category.CategoryName;
            return category;
        }

        public void DeleteCategory(int id)
        {
            var category = GetCategory(id);
            _categories.Remove(category);
        }
    }
}