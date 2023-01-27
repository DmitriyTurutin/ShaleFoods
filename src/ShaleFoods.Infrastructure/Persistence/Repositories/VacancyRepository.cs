using Microsoft.EntityFrameworkCore;
using ShaleFoods.Application.Common.Interfaces.Persistance;
using ShaleFoods.Domain.Vacancy;
using ShaleFoods.Domain.Vacancy.ValueObjects;

namespace ShaleFoods.Infrastructure.Persistence;

public class VacancyRepository : IVacancyRepository
{
    private readonly ShaleFoodsDbContext _context;

    public VacancyRepository(ShaleFoodsDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Vacancy? vacancy)
    {
        if (vacancy is not null) _context.Vacancies.Add(vacancy);
        await _context.SaveChangesAsync();
    }

    public async Task<Vacancy?> GetAsync(VacancyId id)
    {
        return await _context.Vacancies
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Vacancy>> GetAllAsync()
    {
        return await _context.Vacancies
            .ToListAsync();
    }

    public async Task UpdateAsync(Vacancy vacancy)
    {
        _context.Vacancies.Update(vacancy);
        await _context.SaveChangesAsync();
    }

    public async Task<Vacancy?> DeleteAsync(VacancyId id)
    {
        var vacancy = await _context.Vacancies
            .FirstOrDefaultAsync(x => x.Id == id);
        if (vacancy is null)
        {
            return null;
        }

        _context.Vacancies.Remove(vacancy);
        await _context.SaveChangesAsync();

        return vacancy;
    }
}