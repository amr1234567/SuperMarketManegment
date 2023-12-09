using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;
using UseCases.UseCasesInterfaces;

namespace UseCases.ProductsUseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepositry _productRepositry;

        public SellProductUseCase(IProductRepositry productRepositry)
        {
            _productRepositry = productRepositry;
        }

        public void Execute(int productId, int qty)
        {
            var product = _productRepositry.GetProductById(productId);
            if (product == null) return;
            product.Quantity -= qty;
            _productRepositry.EditProduct(product);
        }
    }
}
