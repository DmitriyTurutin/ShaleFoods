using MediatR;
using ShaleFoods.Application.Vacancies.Common;

namespace ShaleFoods.Application.Vacancies.Commands;

public record AddVacancyCommand(
    string Title,
    int Experience,
    int MinSalary,
    int MaxSalary,
    string Description,
    List<string> RequiredSkills, 
    List<string> GoodTodKnow,
    string WorkingConditions) : IRequest<VacancyResult>;