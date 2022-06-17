using ProductCodeOldAPIs.Models;

namespace ProductCodeOldAPIs.Services.Interfaces
{
    public interface IProductSpecificationService
    {
        Task<bool> SaveProductCodeOld(ProductSpecification tModel);
        Task<bool> UpdateProductCodeOld(ProductSpecification tModel);
        Task<ResponseViewModel<ProductSpecification>> GetAllProductCode(int skip, int take);
        Task<ResponseViewModel<ProductSpecification>> SearchProductCode(string productCode, string productDescription, int skip, int take);
        Task<bool> Delete(int id);
    }
}
