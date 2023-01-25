using ShaleFoods.Domain.Vacancy.ValueObjects;

namespace Domain.UnitTests.ValueObjects;

public class SalaryForkTests
{
    [Fact]
    public void CreateUnique_WithValidArguments_ReturnsSalaryFork()
    {
        // Arrange
        var minSalary = 1000;
        var maxSalary = 2000;

        // Act
        var salaryFork = SalaryFork.CreateUnique(minSalary, maxSalary);

        // Assert
        Assert.NotNull(salaryFork);
        Assert.Equal(minSalary, salaryFork.MinSalary);
        Assert.Equal(maxSalary, salaryFork.MaxSalary);
    }

    [Fact]
    public void CreateUnique_WithInvalidMinSalary_ThrowsArgumentException()
    {
        // Arrange
        var minSalary = -1000;
        var maxSalary = 2000;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => SalaryFork.CreateUnique(minSalary, maxSalary));
        Assert.Equal("Salary should not be negative", exception.Message);
    }

    [Fact]
    public void CreateUnique_WithInvalidMaxSalary_ThrowsArgumentException()
    {
        // Arrange
        var minSalary = 1000;
        var maxSalary = 0;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => SalaryFork.CreateUnique(minSalary, maxSalary));
        Assert.Equal("Max salary should be greater than min salary", exception.Message);
    }

    [Fact]
    public void Equals_WithDifferentSalaryFork_ReturnsFalse()
    {
        // Arrange
        var salaryFork1 = SalaryFork.CreateUnique(1000, 2000);
        var salaryFork2 = SalaryFork.CreateUnique(2000, 4000);

        // Act & Assert
        Assert.False(salaryFork1.Equals(salaryFork2));
    }

    [Fact]
    public void Equals_WithSameSalaryFork_ReturnsTrue()
    {
        // Arrange
        var salaryFork1 = SalaryFork.CreateUnique(1000, 2000);
        var salaryFork2 = SalaryFork.CreateUnique(1000, 2000);
        
        Assert.True(salaryFork1.Equals(salaryFork2));
    }
    
    [Fact]
    public void GetHashCode_WithDifferentSalaryFork_ReturnsDifferentValue()
    {
        // Arrange
        var salaryFork1 = SalaryFork.CreateUnique(1000, 2000);
        var salaryFork2 = SalaryFork.CreateUnique(2000, 4000);

        // Act
        var hashCode1 = salaryFork1.GetHashCode();
        var hashCode2 = salaryFork2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }

    [Fact]
    public void GetHashCode_WithSameSalaryFork_ReturnsSameValue()
    {
        // Arrange
        var salaryFork1 = SalaryFork.CreateUnique(1000, 2000);
        var salaryFork2 = SalaryFork.CreateUnique(1000, 2000);

        // Act
        var hashCode1 = salaryFork1.GetHashCode();
        var hashCode2 = salaryFork2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }
}
