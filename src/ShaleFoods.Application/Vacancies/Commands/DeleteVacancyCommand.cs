using MediatR;
using ShaleFoods.Application.Vacancies.Common;
using ShaleFoods.Domain.Vacancy.ValueObjects;

namespace ShaleFoods.Application.Vacancies.Commands;

public record DeleteVacancyCommand(
    VacancyId Id) : IRequest<VacancyResult>;