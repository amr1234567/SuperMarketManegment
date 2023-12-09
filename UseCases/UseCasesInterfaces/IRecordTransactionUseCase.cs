namespace UseCases.UseCasesInterfaces
{
    public interface IRecordTransactionUseCase
    {
        void Execute(string CashierName, int productId, int Soldqty, int Beforeqty);
    }
}