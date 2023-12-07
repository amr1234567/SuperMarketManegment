using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;

namespace Plugin.InMemory
{
    public class ProductInMemoryRepositry : IProductRepositry
    {
        private List<Product> _products;
        public ProductInMemoryRepositry()
        {
            _products = new List<Product>()
            {
                new Product { Id = 1,Name="Product Test 1",CategoryId=1,Price=100,Quantity=200},
                new Product { Id = 2,Name="Product Test 2",CategoryId=1,Price=100,Quantity=200},
                new Product { Id = 3,Name="Product Test 3",CategoryId=2,Price=800,Quantity=200},
                new Product { Id = 4,Name="Product Test 4",CategoryId=1,Price=6600,Quantity=200},
                new Product { Id = 5,Name="Product Test 5",CategoryId=4,Price=500,Quantity=200},
                new Product { Id = 6,Name="Product Test 6",CategoryId=6,Price=600,Quantity=200},
                new Product { Id = 7,Name="Product Test 7",CategoryId=5,Price=400,Quantity=200},
                new Product { Id = 8,Name="Product Test 8",CategoryId=2,Price=700,Quantity=200},
            };
        }


        public void AddProduct(Product product)
        {
            if (!string.IsNullOrEmpty(GetProductByName(product.Name)?.Name)) return;
            if (_products.Count() > 0)
            {
                product.Id = _products.Max(x => x.Id) + 1;
            }
            else
            {
                product.Id = 1;
            }
            _products.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id) ?? new Product();
        }

        public Product GetProductByName(string name)
        {
            var product = _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            return product ?? new Product();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _products.Where(p=>p.CategoryId == categoryId);
        }

        public void RemoveProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            { 
                _products.Remove(product);
            }
        }
    }
}
