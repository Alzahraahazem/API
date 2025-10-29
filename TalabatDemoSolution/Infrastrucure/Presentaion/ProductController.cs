using Microsoft.AspNetCore.Mvc;
using Sahred.DTOS;
using ServiceAbstractionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PeresentaionLayer
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController (IServiceManager _serviceManager) : ControllerBase
    {


        // Get All Products
        [HttpGet] //Get::baseUrl/api/Product
        public async Task<ActionResult<IEnumerable<ProductHeaderValue>>> GetAllProducts()
        {
            var products = await _serviceManager.ProductService.GetAllProductAsync();
            return Ok(products);
        }

        // Get Product By Id
        [HttpGet("{id}")]//Get::baseUrl/api/Product/4
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _serviceManager.ProductService.GetAllProductByIdAsync(id);
            return Ok(product);
        }
        // Get All Brands
        [HttpGet("brands")]//Get::baseUrl/api/Products/brands
        public async Task<ActionResult<BrandDto>> GetAllBrands()
        {
            var brands= await _serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(brands);
        }
        // Get All Types
        [HttpGet("types")]//Get::baseUrl/api/Products/types
        public async Task<ActionResult<TypeDto>> GetAllTypes()
        {
            var types = await _serviceManager.ProductService.GetAllTypesAsync();
            return Ok(types);
        }

    }
}
