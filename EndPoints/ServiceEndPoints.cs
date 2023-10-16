using APIBookCatalyst.DTOs;
using APIBookCatalyst.Interfaces;

namespace APIBookCatalyst.EndPoints
{
    public static class ServiceEndPoints
    {
        public static void MapCategoryServiceEndpoints(this WebApplication app)
        {
            app.MapGet("/api/categories", async (ICategoryRepository service) =>
            {
                return await service.GetAsync();
            });

            app.MapGet("/api/categories/{id}", async (ICategoryRepository service, string id) =>
            {
                var category = await service.GetAsync(id);

                if (category == null) TypedResults.NotFound();

                return category;
            });

            app.MapPost("/api/categories", async (ICategoryRepository service, CategoryDto categoryDto) =>
            {
                await service.CreateAsync(categoryDto);

                return TypedResults.Created($"/api/categories/{categoryDto.Id}", categoryDto);
            });

            app.MapPut("/api/categories/{id}", async (ICategoryRepository service, string id, CategoryDto updatedCategory) =>
            {
                var category = await service.GetAsync(id);

                if (category is null) TypedResults.NotFound();

                updatedCategory.Id = category?.Id;

                await service.UpdateAsync(id, updatedCategory);

                return Results.Ok();
            });

            app.MapDelete("/api/categories/{id}", async (ICategoryRepository service, string id) =>
            {
                var category = await service.GetAsync(id);

                if (category is null) TypedResults.NotFound();

                await service.RemoveAsync(id);

                return TypedResults.Ok();
            });
        }


        public static void MapProductServiceEndpoints(this WebApplication app)
        {
            app.MapGet("/api/products", async (IProductRepository service) =>
            {
                return await service.GetAsync();
            });

            app.MapGet("/api/products/{id}", async (IProductRepository service, string id) =>
            {
                var product = await service.GetAsync(id);

                if (product == null) TypedResults.NotFound();

                return product;
            });

            app.MapPost("/api/products", async (IProductRepository service, ProductDto productDto) =>
            {
                  await service.CreateAsync(productDto);

                return TypedResults.Created($"/api/products/{productDto.Id}", productDto);  
            });

            app.MapPut("/api/products/{id}", async (IProductRepository service, string id, ProductDto updatedProduct) =>
            {
                var product = await service.GetAsync(id);

                if (product is null) TypedResults.NotFound();

                updatedProduct.Id = product?.Id;

                await service.UpdateAsync(id, updatedProduct);

                return Results.Ok();
            });

            app.MapDelete("/api/products/{id}", async (IProductRepository service, string id) =>
            {
                var product = await service.GetAsync(id);

                if (product is null) TypedResults.NotFound();

                await service.RemoveAsync(id);

                return TypedResults.NoContent();
            });
        }
    }
}
