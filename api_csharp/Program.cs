using api_csharp.Data;
using api_csharp.Repository;
using api_csharp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_csharp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddEntityFrameworkSqlServer().AddDbContext<SistemaDBContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            );

        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
