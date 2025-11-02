using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Shared;
using Shared.DTOS;
using ServiceAbstractionLayer;
using ServiceLayer.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ProductService(IUnitOfWork _unitOfWork , IMapper _mapper) : IProductService
    {
        #region Types And Brands
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var repo = _unitOfWork.GetRepository<ProductBrand, int>();
            var brands = await repo.GetAllAsync();
            var barndsDtos = _mapper.Map<IEnumerable<BrandDto>>(brands);
            return barndsDtos;
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<TypeDto>>(types);
        } 
        #endregion

        public async Task<PaginatedResult<ProductDto>> GetAllProductAsync(ProductQueryParams queryParams)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            //Create Object From Specification 

            var specs = new ProductWithBrandAndTypeSpecifications(queryParams); //.include(p=>p.ProductType).include(p=>p.ProductBrand)

            var products = await repo.GetAllAsync(specs);

            var mappedProducts =  _mapper.Map<IEnumerable<ProductDto>>(products);

            var countSpecs = new ProductCountSpecifications(queryParams);
            var totalCount = await repo.CountAsync(countSpecs);


            return new PaginatedResult<ProductDto>(queryParams.PageIndex, queryParams.PageSize, totalCount, mappedProducts);

        }

        public async Task<ProductDto> GetAllProductByIdAsync(int id)
        {
            var spec = new ProductWithBrandAndTypeSpecifications(id);
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(spec);
            return _mapper.Map<ProductDto>(product);
        }

        
    }
}
