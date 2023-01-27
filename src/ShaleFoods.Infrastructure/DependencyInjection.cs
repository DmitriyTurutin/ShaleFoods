using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShaleFoods.Application.Common.Interfaces.Persistance;
using ShaleFoods.Infrastructure.Persistence;

namespace ShaleFoods.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // FIXME: Change to use configuration
        services.AddDbContext<ShaleFoodsDbContext>(options =>
            options.UseNpgsql("Server=localhost;Port=5432;Database=mydatabase;Username=myuser;Password=mypassword"));

        services.AddScoped<IVacancyRepository, VacancyRepository>();
        return services;
    }
}
