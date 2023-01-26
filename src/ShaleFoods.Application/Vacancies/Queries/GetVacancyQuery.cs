using MediatR;
using ShaleFoods.Application.Vacancies.Common;
using ShaleFoods.Domain.Vacancy.ValueObjects;

namespace ShaleFoods.Application.Vacancies.Queries;

public record GetVacancyQuery(
    VacancyId Id) : IRequest<VacancyResult>;