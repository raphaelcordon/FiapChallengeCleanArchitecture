using Application.Interfaces.ThirdParty;
using Application.Services.ThirdParty;
using Domain.Entities.ThirdPartyRegister;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Common;

public static class ServiceCollectionExtension
{
    public static ServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperConfig>());
        services.AddServices(configuration);
        services.AddSwaggerGen();

        return (ServiceCollection)services;
    }

    private static ServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("SQLiteConnection")));
        
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IDonorService, DonorService>();
        
        return (ServiceCollection)services;
    }
}