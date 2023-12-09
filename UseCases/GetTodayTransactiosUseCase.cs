using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction = Core.Transaction;
using UseCases.DataSourcePluginsInterfaces;
using UseCases.UseCasesInterfaces;

namespace UseCases
{
    public class GetTodayTransactiosUseCase : IGetTodayTransactiosUseCase
    {
        private readonly ITransactionsRepositry transactionsRepositry;

        public GetTodayTransactiosUseCase(ITransactionsRepositry transactionsRepositry)
        {
            this.transactionsRepositry = transactionsRepositry;
        }

        public IEnumerable<Transaction> Execute(string CashierName)
        {
            return transactionsRepositry.GetTransactionsByDay(CashierName, DateTime.Now);
        }
    }
}
