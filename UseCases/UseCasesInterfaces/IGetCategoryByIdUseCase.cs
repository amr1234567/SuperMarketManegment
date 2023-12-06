using Core;

namespace UseCases.UseCasesInterfaces
{
    public interface IGetCategoryByIdUseCase
    {
        Category Execute(int id);
    }
}