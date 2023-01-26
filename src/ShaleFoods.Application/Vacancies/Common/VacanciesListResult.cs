using ShaleFoods.Domain.Vacancy;

namespace ShaleFoods.Application.Vacancies.Common;

public record VacanciesListResult(
    List<Vacancy> Vacancies
);
