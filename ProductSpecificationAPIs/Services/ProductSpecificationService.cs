using Microsoft.EntityFrameworkCore;
using ProductCodeOldAPIs.Models;
using ProductCodeOldAPIs.Repositories.Interfaces;
using ProductCodeOldAPIs.Services.Interfaces;

namespace ProductCodeOldAPIs.Services
{
    public class ProductSpecificationService : IProductSpecificationService
    {
        private readonly ILogger<ProductSpecificationService> _logger;
        private readonly IEfRepository<ProductSpecification> _productSpecification;

        public ProductSpecificationService(
            ILogger<ProductSpecificationService> logger, IEfRepository<ProductSpecification> productSpecification)
        {
            _logger = logger;
            _productSpecification = productSpecification;
        }

        public async Task<bool> SaveProductCodeOld(ProductSpecification tModel)
        {
            try
            {
                await _productSpecification.AddAsync(tModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> UpdateProductCodeOld(ProductSpecification tModel)
        {
            try
            {
                await _productSpecification.UpdateAsync(tModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ResponseViewModel<ProductSpecification>> GetAllProductCode(int skip, int take)
        {
            try
            {
                int total = 0;
                var query = _productSpecification.Table.AsQueryable();
                var allData = await query.OrderByDescending(x => x.UpdateDate).Get(out total, skip, take).ToListAsync();
                return new ResponseViewModel<ProductSpecification>
                {
                    data = allData,
                    totalCount = total
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResponseViewModel<ProductSpecification>> SearchProductCode(string productCode, string productDescription, int skip, int take)
        {
            try
            {
                int total = 0;
                var query = _productSpecification.Table.Where(x => x.Code.Contains(productCode) || x.Name.Contains(productDescription)).AsQueryable();
                var getData = await query.OrderByDescending(x => x.UpdateDate).Get(out total, skip, take).ToListAsync();
                return new ResponseViewModel<ProductSpecification>
                {
                    data = getData,
                    totalCount = total
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                ProductSpecification model = new ProductSpecification();
                model.Id = id;
                await _productSpecification.DeleteAsync(model);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
