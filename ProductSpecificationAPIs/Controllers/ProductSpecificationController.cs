using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCodeOldAPIs.Models;
using ProductCodeOldAPIs.Models.ViewModel;
using ProductCodeOldAPIs.Services.Interfaces;

namespace ProductCodeOldAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSpecificationController : ControllerBase
    {
        private readonly ILogger<ProductSpecificationController> _logger;
        private readonly IProductSpecificationTestService _productSpecificationTestService;
        private readonly IProductSpecificationService _productSpecificationService;

        public ProductSpecificationController(ILogger<ProductSpecificationController> logger, IProductSpecificationTestService productSpecificationTestService
            ,IProductSpecificationService productSpecificationService)
        {
            _logger = logger;
            _productSpecificationTestService = productSpecificationTestService;
            _productSpecificationService = productSpecificationService;
        }

        [Route("Get-All-Product-Code")]
        [HttpGet]
        public async Task<IActionResult> GetAllProductCode()
        {
            try
            {
                var result = await _productSpecificationService.GetAllProductCode();
                return Ok(new ResponseModel
                {
                    Success = true,
                    data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("Save-Product-Code-Old")]
        [HttpPost]
        public async Task<IActionResult> SaveProductCodeOld(ProductCodeViewModel Obj)
        {
            try
            {
                var result = await _productSpecificationService.SaveProductCodeOld(Obj);
                return Ok(new ResponseModel
                {
                    Success = true,
                    data = result
                });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("Search-Product-Code")]
        [HttpGet]
        public async Task<IActionResult> SearchProductCode(string? ProductCode, string? ProductDescription)
        {
            try
            {
                var result = await _productSpecificationService.SearchProductCode(ProductCode is null ? "" : ProductCode, ProductDescription is null ? "" : ProductDescription);
                return Ok(new ResponseModel
                {
                    Success = true,
                    data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete-Data")]
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var result = await _productSpecificationService.Delete(Id);
                return Ok(new ResponseModel
                {
                    Success = true,
                    data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }
        [Route("Update-Product-Code-Old")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductCodeOld(ProductCodeViewModel Obj)
        {
            try
            {
                var result = await _productSpecificationService.UpdateProductCodeOld(Obj);
                return Ok(new ResponseModel
                {
                    Success = true,
                    data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("Check-Duplicate-Product-Code")]
        [HttpGet]
        public async Task<IActionResult> CheckDuplicateProductCode(string ProductCode)
        {
            try
            {
                var result = await _productSpecificationService.CheckDuplicateProductCode(ProductCode);
                return Ok(new ResponseModel
                {
                    Success = true,
                    data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
