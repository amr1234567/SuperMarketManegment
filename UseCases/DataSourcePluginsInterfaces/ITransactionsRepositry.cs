using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = Core.Transaction;


namespace UseCases.DataSourcePluginsInterfaces
{
    public interface ITransactionsRepositry
    {
        IEnumerable<Transaction> GetTransactionsByDay(string CashierName, DateTime day);
        IEnumerable<Transaction> GetTransactionsByCashierName(string CashierName);
        void Save(string CashierName, int productId, int SoldQuantity, int BeforeQuantity);
        IEnumerable<Transaction> Search(string cashierName, DateTime dateStart, DateTime dateEnd);
    }
}
