﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;
using UseCases.UseCasesInterfaces;

namespace UseCases
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepositry productRepositry;

        public DeleteProductUseCase(IProductRepositry productRepositry)
        {
            this.productRepositry = productRepositry;
        }

        public void Execute(int id)
        {
            productRepositry.RemoveProduct(id);
        }
    }
}
