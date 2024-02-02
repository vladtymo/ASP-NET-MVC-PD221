using BusinessLogic.DTOs;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAll();
        IEnumerable<ProductDto> Get(IEnumerable<int> ids);
        ProductDto? Get(int id);
        int GetCount();
        IEnumerable<CategoryDto> GetAllCategories();
        void Create(CreateProductModel model);
        void Edit(EditProductModel model);
        void Delete(int id);
    }
}
