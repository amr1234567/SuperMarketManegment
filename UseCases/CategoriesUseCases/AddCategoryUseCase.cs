using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;

namespace UseCases.CategoriesUseCases
{
    public class AddCategoryUseCase : IAddCategoryUseCase
    {
        private readonly ICategoryRepositry _categoryRepositry;

        public AddCategoryUseCase(ICategoryRepositry categoryRepositry)
        {
            _categoryRepositry = categoryRepositry;
        }

        public void Execute(Category category)
        {
            _categoryRepositry.AddCategory(category);
        }
    }
}
