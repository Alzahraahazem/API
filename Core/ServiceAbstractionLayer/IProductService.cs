using Shared;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractionLayer
{
    public interface IProductService
    {
        ////GetAllProducts
        Task<PaginatedResult<ProductDto>> GetAllProductAsync(ProductQueryParams queryParams);


        ////Get Product By Id
        Task<ProductDto> GetAllProductByIdAsync(int id);


        ////Get All Types
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();


        ////Get All Brands
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();


    }
}
