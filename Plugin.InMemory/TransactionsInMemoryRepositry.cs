using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UseCases.DataSourcePluginsInterfaces;
using UseCases.UseCasesInterfaces;
using Transaction = Core.Transaction;

namespace Plugin.InMemory
{
    public class TransactionsInMemoryRepositry : ITransactionsRepositry
    {
        private readonly IGetProductByIdUseCase getProduct;
        private List<Transaction> transactions;

        public TransactionsInMemoryRepositry(IGetProductByIdUseCase getProduct) 
        {
            transactions = new List<Transaction>();
            this.getProduct = getProduct;
        }

        public IEnumerable<Transaction> GetTransactionsByCashierName(string CashierName)
        {
            if (string.IsNullOrWhiteSpace(CashierName))
                return transactions;
            else 
                return transactions.Where(x=>x.CashierName.Equals(CashierName,StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Transaction> GetTransactionsByDay(string CashierName, DateTime day)
        {
            var products = transactions.Where(x => x.date.Date == day.Date);
            if (string.IsNullOrEmpty(CashierName))
                return products;
            else
                return products.Where(x => string.Equals(x.CashierName, CashierName, StringComparison.OrdinalIgnoreCase));
        }

        public void Save(string CashierName, int productId, int BeforeQuantity, int SoldQuantity)
        {
            var product = getProduct.Execute(productId);
            var id = 0;
            if (transactions.Count() <= 0 || transactions == null) id = 1;
            else id = transactions.Max(t => t.Id) + 1;
            var newTransaction = new Transaction()
            {
                Id =id,
                date = DateTime.Now,
                ProductId = productId,
                price = product.Price,
                SoldQuantity = SoldQuantity,
                BeforeQuantity = BeforeQuantity,
                ProductName =product.Name,
                CashierName = CashierName
            };
            transactions?.Add(newTransaction);
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime dateStart, DateTime dateEnd)
        {
            var products = transactions.Where(x => x.date.Date >= dateStart.Date && x.date.Date <= dateEnd.Date);
            if (string.IsNullOrEmpty(cashierName))
                return products;
            else
                return products.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
