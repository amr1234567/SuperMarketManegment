using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;

namespace Plugin.DataBase.Sql
{
    public class ProductRepositry : IProductRepositry
    {
        private readonly MarketContext market;

        public ProductRepositry(MarketContext market)
        {
            this.market = market;
        }

        public void AddProduct(Product product)
        {
            if (product != null)
                market.Products.Add(product);
        }

        public void EditProduct(Product product)
        {
            var prod = GetProductById(product.Id);
            if (prod != null)
            {
                prod.Price = product.Price;
                prod.Name = product.Name;
                prod.Quantity = product.Quantity;
                prod.CategoryId = product.CategoryId;
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return market.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            var product = market.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                return product;
            return null;
        }

        public Product GetProductByName(string name)
        {
            var product = market.Products.FirstOrDefault(p => p.Name.Equals(name,StringComparison.OrdinalIgnoreCase));
            if (product != null)
                return product;
            return null;
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            var products = market.Products.Where(p=>p.CategoryId== categoryId);
            if(products.Count() > 0 && products != null)
                return products.ToList();
            return null;
        }

        public void RemoveProduct(int id)
        {
            var prod = GetProductById(id);
            if (prod != null)
                market.Products.Remove(prod);
        }
    }
}
