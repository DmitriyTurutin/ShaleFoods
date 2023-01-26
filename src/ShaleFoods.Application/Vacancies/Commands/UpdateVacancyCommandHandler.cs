using MediatR;
using ShaleFoods.Application.Common.Interfaces.Persistance;
using ShaleFoods.Application.Vacancies.Common;

namespace ShaleFoods.Application.Vacancies.Commands;

public class UpdateVacancyCommandHandler
: IRequestHandler<UpdateVacancyCommand, VacancyResult>
{
    private IVacancyRepository _vacancyRepository;

    public UpdateVacancyCommandHandler(IVacancyRepository vacancyRepository)
    {
        _vacancyRepository = vacancyRepository;
    }

    public Task<VacancyResult> Handle(UpdateVacancyCommand command, CancellationToken cancellationToken)
    {
        var vacancy = _vacancyRepository.GetAsync(command.Id).Result;

        if (vacancy is null)
            throw new ArgumentException("Vacancy not found");

        // Update the properties of the vacancy as needed

        _vacancyRepository.UpdateAsync(vacancy);

        return Task.FromResult(new VacancyResult(vacancy));
    }
}