using ShaleFoods.Domain.Vacancy;
using ShaleFoods.Domain.Vacancy.ValueObjects;

namespace ShaleFoods.Application.Common.Interfaces.Persistance;

public interface IVacancyRepository
{
    Task AddAsync(Vacancy vacancy);
    Task<Vacancy> GetAsync(VacancyId id);
    Task<List<Vacancy>> GetAllAsync();
    Task UpdateAsync(Vacancy vacancy);
    Task<Vacancy> DeleteAsync(VacancyId id);
}