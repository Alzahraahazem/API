using Sahred.DTOS;
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
        Task<IEnumerable<ProductDto>> GetAllProductAsync();


        ////Get Product By Id
        Task<ProductDto> GetAllProductByIdAsync(int id);


        ////Get All Types
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();


        ////Get All Brands
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();


    }
}
