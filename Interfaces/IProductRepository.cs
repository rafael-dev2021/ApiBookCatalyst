using APIBookCatalyst.DTOs;

namespace APIBookCatalyst.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAsync();
        Task<ProductDto?> GetAsync(string id);
        Task CreateAsync(ProductDto newProduct);
        Task UpdateAsync(string id, ProductDto updateProduct);
        Task RemoveAsync(string id);
    }
}
