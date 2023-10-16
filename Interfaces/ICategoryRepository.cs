using APIBookCatalyst.DTOs;

namespace APIBookCatalyst.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAsync();
        Task<CategoryDto?> GetAsync(string id);
        Task CreateAsync(CategoryDto newCategory);
        Task UpdateAsync(string id, CategoryDto updateCategory);
        Task RemoveAsync(string id);
    }
}
