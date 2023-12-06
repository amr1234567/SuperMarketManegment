using Core;

namespace UseCases.UseCasesInterfaces
{
    public interface IGetProductByIdUseCase
    {
        Product Execute(int id);
    }
}