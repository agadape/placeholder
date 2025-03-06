using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_API.models;

namespace Simple_API.data
{
    public interface InterfaceCategory
    {
        public List<Category> GetCategories();
        public Category GetCategory(int id);
        public Category AddCategory(Category category);
        public Category UpdateCategory(Category category);
        public void DeleteCategory(int id);
    }
}