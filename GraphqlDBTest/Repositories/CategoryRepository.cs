using GraphqlDBTest.Context;
using GraphqlDBTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlDBTest.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await context.Category
            .AsNoTracking()
            .Include(x => x.Products)
            .ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await context.Category
            .FindAsync(id);
    }

    public async Task AddCategoryAsync(Category category)
    {
        await context.Category.AddAsync(category);
        await context.SaveChangesAsync();
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        context.Category.Update(category);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await context.Category.FindAsync(id);
        if (category == null)
            throw new Exception("Category not found");
        context.Category.Remove(category);
        await context.SaveChangesAsync();
    }
}