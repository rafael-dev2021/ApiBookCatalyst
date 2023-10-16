using APIBookCatalyst.DTOs;
using APIBookCatalyst.Interfaces;
using APIBookCatalyst.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIBookCatalyst.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<ProductDto> _mongoCollection;
        private readonly IMongoCollection<CategoryDto> _categoryCollection;

        public ProductRepository(IOptions<DbMongoSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
            _mongoCollection = mongoDatabase.GetCollection<ProductDto>(options.Value.ProductsCollectionName);
            _categoryCollection = mongoDatabase.GetCollection<CategoryDto>(options.Value.CategoriesCollectionName);
        }

        public async Task<List<ProductDto>> GetAsync() =>
            await _mongoCollection.Find(_ => true).ToListAsync();

        public async Task<ProductDto?> GetAsync(string id) =>
            await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ProductDto newProduct)
        {
            // Check if the category exists
            var categoryExists = await _categoryCollection
                .Find(c => c.Id == newProduct.CategoryId)
                .AnyAsync();

            if (!categoryExists)
            {
                throw new CategoryValidationException("The category provided is not valid.");
            }

            //The category is valid, create the product 
            await _mongoCollection.InsertOneAsync(newProduct);
        }


        public async Task UpdateAsync(string id, ProductDto updateProduct) =>
            await _mongoCollection.ReplaceOneAsync(x => x.Id == id, updateProduct);

        public async Task RemoveAsync(string id) =>
            await _mongoCollection.DeleteOneAsync(x => x.Id == id);

    }
    public class CategoryValidationException : Exception
    {
        public CategoryValidationException(string message) : base(message)
        {
        }
    }

}
