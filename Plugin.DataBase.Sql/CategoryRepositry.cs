using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;

namespace Plugin.DataBase.Sql
{
    public class CategoryRepositry : ICategoryRepositry
    {
        private readonly MarketContext market;

        public CategoryRepositry(MarketContext market)
        {
            this.market = market;
        }

        public void AddCategory(Category category)
        {
            if (category != null)
                market.Categories.Add(category);
        }

        public void DeleteCategory(int id)
        {
            var cat = GetCategoryById(id);
            if (cat != null)
                market.Categories.Remove(cat);
        }

        public void EditCategory(Category category)
        {
            var cat = GetCategoryById(category.Id);
            if (cat != null)
            {
                cat.Description = category.Description;
                cat.Name = category.Name;
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return market.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var cat = market.Categories.FirstOrDefault(c => c.Id == id);
            if(cat != null) return cat;
            return null;
        }

        public Category GetCategoryByName(string name)
        {
            var cat = market.Categories.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (cat != null) return cat;
            return null;
        }
    }
}
