using Dom.Lib.Models;
using Dom.Lib.Requests.Categories;
using Dom.Lib.Responses;


namespace Dom.Lib.Handlers;

public interface ICategoryHandler
{
    Task<Response<Category?>> CreateAsync(CreateCategoryReq request);
    Task<Response<Category?>> DeleteAsync(DeleteCategoryReq request);
    Task<Response<Category?>> UpdateAsync(UpdateCategoryReq request);
    Task<Response<Category?>> GetByIdAsync(GetCategoryByIdReq request);
    Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesReq request);
}
