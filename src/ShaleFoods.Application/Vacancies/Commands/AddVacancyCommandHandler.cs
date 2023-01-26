using MediatR;
using ShaleFoods.Application.Common.Interfaces.Persistance;
using ShaleFoods.Application.Vacancies.Common;
using ShaleFoods.Domain.Vacancy;
using ShaleFoods.Domain.Vacancy.ValueObjects;

namespace ShaleFoods.Application.Vacancies.Commands;

public class AddVacancyCommandHandler :
    IRequestHandler<AddVacancyCommand, VacancyResult>
{
    private readonly IVacancyRepository _vacancyRepository;

    public AddVacancyCommandHandler(IVacancyRepository vacancyRepository)
    {
        _vacancyRepository = vacancyRepository;
    }

    public Task<VacancyResult> Handle(AddVacancyCommand command, CancellationToken cancellationToken)
    {
        var salaryFork = SalaryFork.CreateUnique(command.MinSalary, command.MaxSalary);
        var vacancy = Vacancy.Create(
            command.Title,
            command.Experience,
            salaryFork,
            command.Description,
            command.RequiredSkills,
            command.GoodTodKnow,
            command.WorkingConditions);

        _vacancyRepository.AddAsync(vacancy);
        return Task.FromResult(new VacancyResult(vacancy));
    }
}