using Core;

namespace UseCases.UseCasesInterfaces
{
    public interface ISearchTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(string CashierName, DateTime DateStart, DateTime DateEnd);
    }
}