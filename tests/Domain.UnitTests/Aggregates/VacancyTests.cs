using ShaleFoods.Domain.Vacancy;
using ShaleFoods.Domain.Vacancy.ValueObjects;

namespace Domain.UnitTests.Aggregates;

public class VacancyTests
{
    [Fact]
    public void Create_WithValidArguments_ReturnsVacancy()
    {
        // Arrange
        var title = "Software Engineer";
        var experience = 3;
        var salaryFork = SalaryFork.CreateUnique(100000, 200000);
        var description = "We are seeking a software engineer with experience in C# and ASP.NET";
        var requiredSkills = new List<string> { "C#", "ASP.NET" };
        var goodToKnow = new List<string> { "Angular" };
        var workingConditions = "Remote work";

        // Act
        var vacancy = Vacancy.Create(title, experience, salaryFork, description, requiredSkills, goodToKnow,
            workingConditions);

        // Assert
        Assert.NotNull(vacancy);
        Assert.Equal(title, vacancy.Title);
        Assert.Equal(experience, vacancy.Experience);
        Assert.Equal(salaryFork, vacancy.Salary);
        Assert.Equal(description, vacancy.Description);
        Assert.Equal(requiredSkills, vacancy._requiredSkills);
        Assert.Equal(goodToKnow, vacancy._goodTodKnow);
        Assert.Equal(workingConditions, vacancy.WorkingConditions);
        Assert.NotEqual(DateTime.MinValue, vacancy.CreatedAt);
        Assert.NotEqual(DateTime.MinValue, vacancy.UpdatedAt);
    }

    [Fact]
    public void Create_WithInvalidTitle_ThrowsArgumentException()
    {
        // Arrange
        var title = "";
        var experience = 3;
        var salaryFork = SalaryFork.CreateUnique(100000, 200000);
        var description = "We are seeking a software engineer with experience in C# and ASP.NET";
        var requiredSkills = new List<string> { "C#", "ASP.NET" };
        var goodToKnow = new List<string> { "Angular" };
        var workingConditions = "Remote work";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            Vacancy.Create(title, experience, salaryFork, description, requiredSkills, goodToKnow, workingConditions));
        Assert.Equal("Title should not be empty!", exception.Message);
    }

    [Fact]
    public void Create_WithNegativeExperience_ThrowsArgumentException()
    {
        // Arrange
        var title = "Software Engineer";
        var experience = -3;
        var salaryFork = SalaryFork.CreateUnique(100000, 200000);
        var description = "We are seeking a software engineer with experience in C# and ASP.NET";
        var requiredSkills = new List<string> { "C#", "ASP.NET" };
        var goodToKnow = new List<string> { "Angular" };
        var workingConditions = "Remote work";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            Vacancy.Create(title, experience, salaryFork, description, requiredSkills, goodToKnow, workingConditions));
        Assert.Equal("Experience should not be negative!", exception.Message);
    }
}