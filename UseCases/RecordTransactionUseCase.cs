using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataSourcePluginsInterfaces;
using UseCases.UseCasesInterfaces;

namespace UseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionsRepositry transactionsRepositry;

        public RecordTransactionUseCase(ITransactionsRepositry transactionsRepositry)
        {
            this.transactionsRepositry = transactionsRepositry;
        }

        public void Execute(string CashierName, int productId, int BeforeQuantity, int SoldQuantity)
        {

            transactionsRepositry.Save(CashierName,productId, BeforeQuantity, SoldQuantity);
        }
    }
}
