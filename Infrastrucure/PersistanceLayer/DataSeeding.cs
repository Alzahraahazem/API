using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersistanceLayer
{
    public class DataSeeding(StoreDbContext _storeDbContext) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            // Production
            if ((await _storeDbContext.Database.GetPendingMigrationsAsync()).Any())
            {
                await _storeDbContext.Database.MigrateAsync();
            }

            if (!_storeDbContext.ProductBrand.Any())
            {
                //var productBrandsData = await File.ReadAllTextAsync(@"..\Infrastrucure\PersistanceLayer\Data\DataSeed\brands.json");
                var productBrandsData = File.OpenRead(@"..\Infrastrucure\PersistanceLayer\Data\DataSeed\brands.json");
                // Convert String To C# Object

                var brands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(productBrandsData);

                if (brands is not null && brands.Any())
                {
                    await _storeDbContext.ProductBrand.AddRangeAsync(brands);
                }

            }

            if (!_storeDbContext.ProductType.Any())
            {
                var ProductTypeData = File.OpenRead(@"..\Infrastrucure\PersistanceLayer\Data\DataSeed\types.json");
                // Convert String To C# Object

                var types = await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypeData);

                if (types is not null && types.Any())
                {
                    await _storeDbContext.ProductType.AddRangeAsync(types);
                }

            }


            if (!_storeDbContext.Products.Any())
            {
                var productData = File.OpenRead(@"..\Infrastrucure\PersistanceLayer\Data\DataSeed\products.json");
                // Convert String To C# Object

                var products = await JsonSerializer.DeserializeAsync<List<Product>>(productData);

                if (products is not null && products.Any())
                {
                    await _storeDbContext.Products.AddRangeAsync(products);
                }

            }

            await _storeDbContext.SaveChangesAsync();
        }


    }
}

