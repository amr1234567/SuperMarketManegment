using Core;

namespace UseCases.UseCasesInterfaces
{
    public interface IGetProductsByCategoryIdUseCase
    {
        IEnumerable<Product> Execute(int CategoryId);
    }
}