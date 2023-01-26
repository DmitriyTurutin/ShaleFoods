using MediatR;
using ShaleFoods.Application.Common.Interfaces.Persistance;
using ShaleFoods.Application.Vacancies.Common;

namespace ShaleFoods.Application.Vacancies.Queries;

public class GetAllVacancyQueryHandler
    : IRequestHandler<GetAllVacancyQuery, VacanciesListResult>
{
    private IVacancyRepository _vacancyRepository;

    public GetAllVacancyQueryHandler(IVacancyRepository vacancyRepository)
    {
        _vacancyRepository = vacancyRepository;
    }

    public Task<VacanciesListResult> Handle(GetAllVacancyQuery request, CancellationToken cancellationToken)
    {
        var vacancies = _vacancyRepository.GetAllAsync().Result;
        return Task.FromResult(new VacanciesListResult(vacancies));
    }
}