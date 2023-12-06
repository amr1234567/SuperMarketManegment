using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;

namespace UseCases.CategoriesUseCases
{
    public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
    {
        private readonly ICategoryRepositry _categoryRepositry;

        public GetCategoryByIdUseCase(ICategoryRepositry categoryRepositry)
        {
            _categoryRepositry = categoryRepositry;
        }

        public Category Execute(int id)
        {

            var category = _categoryRepositry.GetCategoryById(id);
            if (category == null) return new Category();
            return category;
        }
    }
}
