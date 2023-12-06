using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataSourcePluginsInterfaces
{
    public interface ICategoryRepositry
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        Category GetCategoryByName(string name);
        void AddCategory(Category category);
        void EditCategory (Category category);
        void DeleteCategory(int id);
    }
}
