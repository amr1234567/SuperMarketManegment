using Core;

namespace UseCases.UseCasesInterfaces
{
    public interface IGetTodayTransactiosUseCase
    {
        IEnumerable<Transaction> Execute(string CashierName);
    }
}