using MediatR;
using ShaleFoods.Application.Common.Interfaces.Persistance;
using ShaleFoods.Application.Vacancies.Common;
using ShaleFoods.Domain.Vacancy;

namespace ShaleFoods.Application.Vacancies.Queries;

public class GetVacancyQueryHandler
    : IRequestHandler<GetVacancyQuery, VacancyResult>
{
    private readonly IVacancyRepository _vacancyRepository;

    public GetVacancyQueryHandler(IVacancyRepository vacancyRepository)
    {
        _vacancyRepository = vacancyRepository;
    }

    public Task<VacancyResult> Handle(GetVacancyQuery query, CancellationToken cancellationToken)
    {
        var vacancy = _vacancyRepository.GetAsync(query.Id).Result;
        
        return Task.FromResult(new VacancyResult(vacancy));
    }
}