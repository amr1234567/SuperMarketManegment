using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;
using UseCases.UseCasesInterfaces;

namespace Plugin.DataBase.Sql
{
    public class TransactionsRepositry : ITransactionsRepositry
    {
        private readonly MarketContext market;

        public TransactionsRepositry(MarketContext market, IGetProductByIdUseCase getProduct)
        {
            this.market = market;
            GetProduct = getProduct;
        }

        public IGetProductByIdUseCase GetProduct { get; }

        public IEnumerable<Transaction> GetTransactionsByCashierName(string CashierName)
        {
            if (!string.IsNullOrWhiteSpace(CashierName))
                return market.transactions.Where(x => x.CashierName.Equals(CashierName, StringComparison.OrdinalIgnoreCase)).ToList();
            return null;
        }

        public IEnumerable<Transaction> GetTransactionsByDay(string CashierName, DateTime day)
        {
            var products = market.transactions.Where(x => x.date.Date == day.Date);
            if (products.Count() > 0 && products != null)
            {
                if (!string.IsNullOrEmpty(CashierName))
                {
                    var newProducts = products.Where(x => x.CashierName.ToLower() == CashierName.ToLower());
                    if (newProducts.Count() > 0 && newProducts != null)
                        return newProducts.ToList();
                }
                return null;
            }
            else return null;
        }

        public void Save(string CashierName, int productId, int BeforeQuantity , int SoldQuantity)
        {
            var product = GetProduct.Execute(productId);
            
            var newTransaction = new Transaction()
            {
                date = DateTime.Now,
                ProductId = productId,
                price = product.Price,
                SoldQuantity = SoldQuantity,
                BeforeQuantity = BeforeQuantity,
                CashierName = CashierName,
                ProductName = product.Name,
            };
            market.transactions.Add(newTransaction);
            market.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime dateStart, DateTime dateEnd)
        {
            var products = market.transactions.Where(x => x.date.Date >= dateStart.Date && x.date.Date <= dateEnd.Date.AddDays(1).Date);
            if (products.Count() > 0 && products != null)
            {
                if (!string.IsNullOrEmpty(cashierName))
                { 
                    var newProducts = products.Where(x => x.CashierName.ToLower() == cashierName.ToLower());
                    if (newProducts.Count() > 0 && newProducts != null)
                        return newProducts.ToList();
                }
                return null;
            }
            else return null;
        }
    }
}
