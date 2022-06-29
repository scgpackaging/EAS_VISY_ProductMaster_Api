using Microsoft.EntityFrameworkCore;
using ProductCodeOldAPIs.Models;
using ProductCodeOldAPIs.Models.ViewModel;
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

        public async Task<bool> SaveProductCodeOld(ProductCodeViewModel tModel)
        {
            try
            {
                ProductSpecification model = new ProductSpecification();
                model.Code = tModel.ProductCode;
                model.Name = tModel.ProductDescription;
                model.CupStack = tModel.CupStack;
                model.StackBox = tModel.StackBox;
                model.CupBox = tModel.CupBox;
                model.CupPallet = tModel.CupPallet;
                model.CupCon = tModel.CupCon;
                model.PalletizerPattern = tModel.PalletizerPattern;

                await _productSpecification.AddAsync(model);

                string spId = model.Id.ToString();
                model.SapCode = spId;
                await _productSpecification.UpdateAsync(model);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> UpdateProductCodeOld(ProductCodeViewModel tModel)
        {
            try
            {
                ProductSpecification model = new ProductSpecification();
                model.Id = tModel.Id;
                model.Code = tModel.ProductCode;
                model.Name = tModel.ProductDescription;
                model.CupStack = tModel.CupStack;
                model.StackBox = tModel.StackBox;
                model.CupBox = tModel.CupBox;
                model.CupPallet = tModel.CupPallet;
                model.CupCon = tModel.CupCon;
                model.PalletizerPattern = tModel.PalletizerPattern;
                model.SapCode = tModel.SapCode;

                await _productSpecification.UpdateAsync(model);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ResponseViewModel<ProductCodeViewModel>> GetAllProductCode()
        {
            try
            {
                int total = 0;
                var query = _productSpecification.Table.AsQueryable();
                var allData = await query.OrderByDescending(x => x.UpdateDate).Get(out total).ToListAsync();
                List<ProductCodeViewModel> result = new List<ProductCodeViewModel>();
                foreach (var item in allData)
                {
                    result.Add(new ProductCodeViewModel()
                    {
                        Id = item.Id,
                        SapCode = item.SapCode,
                        ProductCode = item.Code,
                        ProductDescription = item.Name,
                        CupStack = item.CupStack,
                        StackBox = item.StackBox,
                        CupBox = item.CupBox,
                        CupPallet = item.CupPallet,
                        CupCon = item.CupCon,
                        PalletizerPattern = item.PalletizerPattern,
                        UpdateDate = item.UpdateDate.ToString("dd/MM/yyyy HH:mm")
                    });
                }
                return new ResponseViewModel<ProductCodeViewModel>
                {
                    data = result,
                    totalCount = total
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResponseViewModel<ProductCodeViewModel>> SearchProductCode(string productCode, string productDescription)
        {
            try
            {
                int total = 0;
                var query = _productSpecification.Table.Where(x => x.Code.Contains(productCode) && x.Name.Contains(productDescription)).AsQueryable();
                var getData = await query.OrderByDescending(x => x.UpdateDate).Get(out total).ToListAsync();

                List<ProductCodeViewModel> result = new List<ProductCodeViewModel>();
                foreach (var item in getData)
                {
                    result.Add(new ProductCodeViewModel()
                    {
                        Id = item.Id,
                        SapCode = item.SapCode,
                        ProductCode = item.Code,
                        ProductDescription = item.Name,
                        CupStack = item.CupStack,
                        StackBox = item.StackBox,
                        CupBox = item.CupBox,
                        CupPallet = item.CupPallet,
                        CupCon = item.CupCon,
                        PalletizerPattern = item.PalletizerPattern,
                        UpdateDate = item.UpdateDate.ToString("dd/MM/yyyy HH:mm")
                    });
                }

                return new ResponseViewModel<ProductCodeViewModel>
                {
                    data = result,
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
        public async Task<bool> CheckDuplicateProductCode(string productCode)
        {
            try
            {
                var data = await _productSpecification.GetAsync(x => x.Code.Equals(productCode));
                if (data.Count() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
