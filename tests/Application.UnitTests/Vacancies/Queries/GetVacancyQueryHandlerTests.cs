using Moq;
using ShaleFoods.Application.Common.Interfaces.Persistance;
using ShaleFoods.Application.Vacancies.Common;
using ShaleFoods.Application.Vacancies.Queries;
using ShaleFoods.Domain.Vacancy;
using ShaleFoods.Domain.Vacancy.ValueObjects;
using Xunit;

namespace Application.UnitTests.Vacancies.Queries;

public class GetVacancyQueryHandlerTests
{
    private readonly GetVacancyQueryHandler _handler;
    private readonly Mock<IVacancyRepository> _vacancyRepositoryMock;

    public GetVacancyQueryHandlerTests()
    {
        _vacancyRepositoryMock = new Mock<IVacancyRepository>();
        _handler = new GetVacancyQueryHandler(_vacancyRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnVacancyResult()
    {
        // Arrange
        var query = new GetVacancyQuery(VacancyId.CreateUnique());
        var expectedVacancy = Vacancy.Create(
            "Vacancy Title",
            2,
            SalaryFork.CreateUnique(1000, 2000),
            "Vacancy Description",
            new List<string>{"Required Skill 1", "Required Skill 2"},
            new List<string>{"Good to Know 1", "Good to Know 2"},
            "Working Conditions");
        _vacancyRepositoryMock.Setup(x => x.GetAsync(query.Id)).ReturnsAsync(expectedVacancy);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.IsType<VacancyResult>(result);
        Assert.Equal(expectedVacancy, result.Vacancy);
    }
}
