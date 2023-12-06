using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;

namespace Plugin.InMemory
{
    public class CategoryInMemoryRepositry : ICategoryRepositry
    {
        private List<Category> _categories;
        public CategoryInMemoryRepositry() 
        {
            _categories = new List<Category>()
            {
                new Category { Id = 1, Name = "Test1", Description = "Test Test 1" },
                new Category { Id = 2, Name = "Test2", Description = "Test Test 2" },
                new Category { Id = 3, Name = "Test3", Description = "Test Test 3" },
                new Category { Id = 4, Name = "Test4", Description = "Test Test 4" },
                new Category { Id = 5, Name = "Test5", Description = "Test Test 5" },
                new Category { Id = 6, Name = "Test6", Description = "Test Test 6" },
            };
        }

        public void AddCategory(Category category)
        {
            if (!string.IsNullOrEmpty(GetCategoryByName(category.Name)?.Name)) return;
            if (_categories.Count > 0)
            {
                category.Id = _categories.Max(x => x.Id) + 1;
            }
            else { category.Id = 1; }
            _categories.Add(category);
        }

        public void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
                _categories?.Remove(category);
            
        }

        public void EditCategory(Category category)
        {
            var cat = GetCategoryById(category.Id);
            if (cat == null) return;
            cat.Name = category.Name;
            cat.Description = category.Description;
        }

        public IEnumerable<Category> GetCategories()
        {
           return _categories;
        }

        public Category GetCategoryById(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public Category GetCategoryByName(string name)
        {
            var category = _categories.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
           
            return category ?? new Category();
        }
    }
}
