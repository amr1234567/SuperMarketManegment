using Core;

namespace UseCases
{
    public interface IGetCategoryByIdUseCase
    {
        Category Execute(int id);
    }
}