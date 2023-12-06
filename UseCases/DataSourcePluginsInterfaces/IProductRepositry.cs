using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataSourcePluginsInterfaces
{
    public interface IProductRepositry
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Product GetProductByName(string name);
        void AddProduct (Product product);
        void RemoveProduct (int id);
    }
}
