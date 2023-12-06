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
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        private readonly IProductRepositry productRepositry;

        public GetProductByIdUseCase(IProductRepositry productRepositry)
        {
            this.productRepositry = productRepositry;
        }

        public Product Execute(int id)
        {
            return productRepositry.GetProductById(id);
        }
    }
}
