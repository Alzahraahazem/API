
using DomainLayer1.Interfaces;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer;
using PersistanceLayer.Data;

namespace TalabatDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoredDbContext>(options =>

            options.UseSqlServer(builder.Configuration.GetConnectionString("DeafultConnection"))

            );

            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            #endregion

            var app = builder.Build();

           using  var scope = app.Services.CreateScope();

            var seddobject= scope.ServiceProvider.GetRequiredService<IDataSeeding>();

            seddobject.DataSeed();

           //Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();



            app.MapControllers();

            app.Run();
        }
    }
}
