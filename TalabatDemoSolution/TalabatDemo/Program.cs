using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersistanceLayer;
using PersistanceLayer.Data;
using PersistanceLayer.Repositories;
using ServiceAbstractionLayer;
using ServiceLayer;
using ServiceLayer.MappingProfiles;

namespace TalabatDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            #region Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            #region Register User-Defined Services
            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            #region Mapping Register
            ////builder.Services.AddAutoMapper(p => p.AddProfile(new ProductProfile()));
            ////builder.Services.AddAutoMapper(p => p.AddProfiles(new ProductProfile()));
            ////builder.Services.AddAutoMapper(typeof(ServiceLayerAssemblyReference).Assembly);// AutoMapper 14.0 
            #endregion

            builder.Services.AddAutoMapper((x) => { }, typeof(ServiceLayerAssemblyReference).Assembly); // AutoMapper 15.0
            builder.Services.AddScoped<IServiceManager, ServiceManager>();

            #endregion

            #endregion

            var app = builder.Build();

            using var scope = app.Services.CreateScope(); //Manual Injection
            var seedObj = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await seedObj.DataSeedAsync();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
