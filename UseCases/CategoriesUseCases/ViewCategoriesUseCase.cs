using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;

namespace UseCases.CategoriesUseCases
{
    public class ViewCategoriesUseCase : IViewCategoriesUseCase
    {
        private readonly ICategoryRepositry _categoryInterface;

        public ViewCategoriesUseCase(ICategoryRepositry categoryInterface)
        {
            _categoryInterface = categoryInterface;
        }

        public IEnumerable<Category> Execute()
        {
            return _categoryInterface.GetCategories();
        }
    }
}
