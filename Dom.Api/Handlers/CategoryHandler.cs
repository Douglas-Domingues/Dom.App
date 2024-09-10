using Dom.Lib.Handlers;
using Dom.Lib.Models;
using Dom.Lib.Requests.Categories;
using Dom.Lib.Responses;
using Dom.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Dom.Api.Handlers;

public class CategoryHandler(AppDbContext context) : ICategoryHandler
{
    public async Task<Response<Category?>> CreateAsync(CreateCategoryReq request)
    {
        try
        {
            var category = new Category()
            {
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, 201, "Category successfully created.");
        }
        catch
        {
            return new Response<Category?>(null, 500, "Something went wrong creating the new category");
        }
    }

    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdReq request)
    {
        try
        {
            var category = await context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == request.Id && c.UserId == request.UserId);

            return (category == null)
                ? new Response<Category?>(null, 404, "No results for this Id")
                : new Response<Category?>(category);
        }
        catch
        {
            return new Response<Category?>(null, 500, "Something went wrong retrieving the category");
        }
    }

    public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesReq request)
    {
        try
        {
            var query = context.Categories
            .AsNoTracking()
            .Where(c => c.UserId == request.UserId)
            .OrderBy(c => c.Id);

            var categories = await query
                .Skip(request.PageSize * (request.PageNumber - 1))
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Category>?>(
                categories, count, request.PageNumber, request.PageSize);
        }
        catch
        {
            return new PagedResponse<List<Category>?>(null, 500, "Something went wrong retrieving the results");
        }
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryReq request)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id && c.UserId == request.UserId);

            if (category == null)
                return new Response<Category?>(null, 404, "No results for this Id");

            category.Title = request.Title;
            category.Description = request.Description;

            context.Categories.Update(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, message: "Category successfully updated");
        }
        catch 
        {
            return new Response<Category?>(null, 500, "Something went wrong updating the category");
        }
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryReq request)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id && c.UserId == request.UserId);

            if (category == null)
                return new Response<Category?>(null, 404, "No results for this Id");
            
            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, message: "Category successfully removed");            
        }
        catch
        {
            return new Response<Category?>(null, 500, "Something went wrong removing the category");
        }
    }
}
