using Microsoft.EntityFrameworkCore;
using ShaleFoods.Domain.Vacancy;

namespace ShaleFoods.Infrastructure.Persistence;

public class ShaleFoodsDbContext : DbContext
{
    public ShaleFoodsDbContext(DbContextOptions<ShaleFoodsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vacancy> Vacancies { get; set; } = null!;
}