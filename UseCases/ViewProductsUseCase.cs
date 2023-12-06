using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;
using UseCases.UseCasesInterfaces;

namespace UseCases
{
    public class ViewProductsUseCase : IViewProductsUseCase
    {
        private readonly IProductRepositry _productRepositry;

        public ViewProductsUseCase(IProductRepositry productRepositry)
        {
            _productRepositry = productRepositry;
        }

        public IEnumerable<Product> Execute()
        {
            return _productRepositry.GetAllProducts();
        }
    }
}
