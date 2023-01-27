using Moq;
using ShaleFoods.Application.Common.Interfaces.Persistance;
using ShaleFoods.Application.Vacancies.Common;
using ShaleFoods.Application.Vacancies.Queries;
using ShaleFoods.Domain.Vacancy;
using ShaleFoods.Domain.Vacancy.ValueObjects;
using Xunit;

namespace Application.UnitTests.Vacancies.Queries;

public class GetAllVacancyQueryHandlerTests
{
    private readonly GetAllVacancyQueryHandler _handler;
    private readonly Mock<IVacancyRepository> _vacancyRepositoryMock;

    public GetAllVacancyQueryHandlerTests()
    {
        _vacancyRepositoryMock = new Mock<IVacancyRepository>();
        _handler = new GetAllVacancyQueryHandler(_vacancyRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnVacanciesListResult()
    {
        // Arrange
        var query = new GetAllVacancyQuery();
        var expectedVacancy1 = Vacancy.Create(
            "Vacancy Title",
            2,
            SalaryFork.CreateUnique(1000, 2000),
            "Vacancy Description",
            new List<string>{"Required Skill 1", "Required Skill 2"},
            new List<string>{"Good to Know 1", "Good to Know 2"},
            "Working Conditions");
        var expectedVacancy2 = Vacancy.Create(
            "Vacancy Title 2",
            5,
            SalaryFork.CreateUnique(3000, 4000),
            "Vacancy Description 2",
            new List<string>{"Required Skill 3", "Required Skill 4"},
            new List<string>{"Good to Know 3", "Good to Know 4"},
            "Working Conditions 2");
        var expectedVacancies = new List<Vacancy?> { expectedVacancy1, expectedVacancy2 };
        _vacancyRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(expectedVacancies);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.IsType<VacanciesListResult>(result);
        Assert.Equal(expectedVacancies, result.Vacancies);
    }
}
