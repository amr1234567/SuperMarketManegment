using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;

namespace UseCases.CategoriesUseCases
{
    public class EditCategoryUseCase : IEditCategoryUseCase
    {
        private readonly ICategoryRepositry _categoryRepositry;

        public EditCategoryUseCase(ICategoryRepositry categoryRepositry)
        {
            _categoryRepositry = categoryRepositry;
        }

        public void Execute(Category category)
        {
            _categoryRepositry.EditCategory(category);
        }
    }
}
