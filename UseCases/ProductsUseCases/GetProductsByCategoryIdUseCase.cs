using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;
using UseCases.UseCasesInterfaces;

namespace UseCases.ProductsUseCases
{
    public class GetProductsByCategoryIdUseCase : IGetProductsByCategoryIdUseCase
    {
        private readonly IProductRepositry _productRepositry;

        public GetProductsByCategoryIdUseCase(IProductRepositry productRepositry)
        {
            _productRepositry = productRepositry;
        }

        public IEnumerable<Product> Execute(int CategoryId)
        {
            return _productRepositry.GetProductsByCategoryId(CategoryId);
        }
    }
}
