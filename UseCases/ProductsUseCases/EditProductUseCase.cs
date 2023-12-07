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
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepositry productRepositry;

        public EditProductUseCase(IProductRepositry productRepositry)
        {
            this.productRepositry = productRepositry;
        }

        public void Execute(Product product)
        {
            productRepositry.AddProduct(product);
        }
    }
}
