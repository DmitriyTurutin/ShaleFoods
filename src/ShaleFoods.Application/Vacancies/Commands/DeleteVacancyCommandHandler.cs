using MediatR;
using ShaleFoods.Application.Common.Interfaces.Persistance;
using ShaleFoods.Application.Vacancies.Common;

namespace ShaleFoods.Application.Vacancies.Commands;

public class DeleteVacancyCommandHandler
: IRequestHandler<DeleteVacancyCommand, VacancyResult>
{
    private readonly IVacancyRepository _vacancyRepository;

    public DeleteVacancyCommandHandler(IVacancyRepository vacancyRepository)
    {
        _vacancyRepository = vacancyRepository;
    }

    public Task<VacancyResult> Handle(DeleteVacancyCommand command, CancellationToken cancellationToken)
    {
        var deleteVacancy = _vacancyRepository.DeleteAsync(command.Id).Result;
        return Task.FromResult(new VacancyResult(deleteVacancy));
    }
}