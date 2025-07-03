using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using API.Data;
using API.Interfaces;
using API.Services;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();

        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPhotoService, PhotoService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));

        return services;
    }
}
