using Application.Interfaces.Food;
using Application.Interfaces.Package;
using Application.Interfaces.ThirdParty;
using Application.Services.FoodService;
using Application.Services.PackageService;
using Application.Services.ThirdPartyService;
using Domain.Interfaces;
using Infrastructure.Database.Repositories;

namespace Presentation.Common;

public static class ServiceCollectionExtension
{
    public static ServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddServices();
        return (ServiceCollection)services;
    }

    private static ServiceCollection AddServices(this IServiceCollection services)
    {
        // services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        // services.AddScoped<IDonorService, DonorService>();
        // services.AddScoped<IReceiverService, ReceiverService>();
        // services.AddScoped<IFoodService, FoodService>();
        // services.AddScoped<IPackageReceivedService, PackageReceivedService>();
        // services.AddScoped<IPackageSentService, PackageSentService>();

        return (ServiceCollection)services;
    }
}