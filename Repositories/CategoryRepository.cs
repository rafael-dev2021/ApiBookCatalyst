using APIBookCatalyst.DTOs;
using APIBookCatalyst.Interfaces;
using APIBookCatalyst.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIBookCatalyst.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<CategoryDto> _mongoCollection;

        public CategoryRepository(IOptions<DbMongoSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var mongoDatabase = mongoClient
                .GetDatabase(options.Value.DatabaseName);
            _mongoCollection = mongoDatabase
                .GetCollection<CategoryDto>(options.Value.CategoriesCollectionName);
        }
        public async Task<List<CategoryDto>> GetAsync() =>
         await _mongoCollection.Find(_ => true).ToListAsync();

        public async Task<CategoryDto?> GetAsync(string id) =>
            await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(CategoryDto newCategory) =>
            await _mongoCollection.InsertOneAsync(newCategory);

        public async Task UpdateAsync(string id, CategoryDto updateCategory) =>
            await _mongoCollection.ReplaceOneAsync(x => x.Id == id, updateCategory);

        public async Task RemoveAsync(string id) =>
            await _mongoCollection.DeleteOneAsync(x => x.Id == id);
    }
}
