using Moq;
using ShaleFoods.Application.Common.Interfaces.Persistance;
using ShaleFoods.Application.Vacancies.Commands;
using ShaleFoods.Application.Vacancies.Common;
using ShaleFoods.Domain.Vacancy;
using ShaleFoods.Domain.Vacancy.ValueObjects;
using Xunit;

namespace Application.UnitTests.Vacancies.Commands;

public class AddVacancyCommandHandlerTests
{
    private readonly AddVacancyCommandHandler _handler;
    private readonly Mock<IVacancyRepository> _vacancyRepositoryMock;

    public AddVacancyCommandHandlerTests()
    {
        _vacancyRepositoryMock = new Mock<IVacancyRepository>();
        _handler = new AddVacancyCommandHandler(_vacancyRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldAddVacancy()
    {
        // Arrange
        var command = new AddVacancyCommand
        (
            "Vacancy Title",
            2,
            1000,
            2000,
            "Vacancy Description",
            new List<string> { "Required Skill 1", "Required Skill 2" },
            new List<string> { "Good to Know 1", "Good to Know 2" },
            "Working Conditions"
        );

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        _vacancyRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Vacancy>()), Times.Once);
        Assert.IsType<VacancyResult>(result);
        Assert.Equal(command.Title, result.Vacancy.Title);
    }
}