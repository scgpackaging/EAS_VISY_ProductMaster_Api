using ProductCodeOldAPIs.Models;
using ProductCodeOldAPIs.Models.ViewModel;

namespace ProductCodeOldAPIs.Services.Interfaces
{
    public interface IProductSpecificationService
    {
        Task<bool> SaveProductCodeOld(ProductCodeViewModel tModel);
        Task<bool> UpdateProductCodeOld(ProductCodeViewModel tModel);
        Task<ResponseViewModel<ProductCodeViewModel>> GetAllProductCode();
        Task<ResponseViewModel<ProductCodeViewModel>> SearchProductCode(string productCode, string productDescription);
        Task<bool> Delete(int id);
        Task<bool> CheckDuplicateProductCode(string productCode);
    }
}
