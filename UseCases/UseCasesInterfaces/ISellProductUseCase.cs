namespace UseCases.UseCasesInterfaces
{
    public interface ISellProductUseCase
    {
        void Execute(int productId, int qty);
    }
}