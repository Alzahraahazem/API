using DomainLayer1.Interfaces;
using DomainLayer1.Models;
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
    public class DataSeeding(StoredDbContext _storedDbContext) : IDataSeeding
    {
        public void DataSeed()
        {
            try
            {
                if (_storedDbContext.Database.GetPendingMigrations().Any())
                {
                    //check all data is migrated if not =>  migrate it
                    _storedDbContext.Database.Migrate();
                }

                if (!_storedDbContext.ProductBrands.Any())
                {
                    //read data
                    var Data = File.ReadAllText(@"..\Infrastructure\PersistanceLayer\Data\Seed Data\brands.json");

                    //Conver String To C# Objects

                    var Brand = JsonSerializer.Deserialize<List<ProductBrand>>(Data);

                    //check that daa not empty

                    if (Brand is not null && Brand.Any())
                    {
                        _storedDbContext.ProductBrands.AddRange(Brand);
                    }
                }


                if (!_storedDbContext.ProductTypes.Any())
                {
                    //read data
                    var Data = File.ReadAllText(@"..\Infrastructure\PersistanceLayer\Data\Seed Data\types.json");

                    //Conver String To C# Objects

                    var Type = JsonSerializer.Deserialize<List<ProductType>>(Data);

                    //check that daa not empty

                    if (Type is not null && Type.Any())
                    {
                        _storedDbContext.ProductTypes.AddRange(Type);
                    }
                }


                if (!_storedDbContext.Products.Any())
                {
                    //read data
                    var Data = File.ReadAllText(@"..\Infrastructure\PersistanceLayer\Data\Seed Data\products.json");

                    //Conver String To C# Objects

                    var Product = JsonSerializer.Deserialize<List<Product>>(Data);

                    //check that daa not empty

                    if (Product is not null && Product.Any())
                    {
                        _storedDbContext.Products.AddRange(Product);
                    }
                }


                _storedDbContext.SaveChanges();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
