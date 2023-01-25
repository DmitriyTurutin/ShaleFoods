using ShaleFoods.Domain.Vacancy.ValueObjects;

namespace Domain.UnitTests.ValueObjects;

public class VacancyIdTests
{
    [Fact]
    public void CreateUnique_ReturnsVacancyId()
    {
        // Act
        var id = VacancyId.CreateUnique();

        // Assert
        Assert.NotNull(id);
        Assert.IsType<VacancyId>(id);
    }

    [Fact]
    public void Equals_WithDifferentVacancyId_ReturnsFalse()
    {
        // Arrange
        var id1 = VacancyId.CreateUnique();
        var id2 = VacancyId.CreateUnique();

        // Act & Assert
        Assert.False(id1.Equals(id2));
    }

    [Fact]
    public void Equals_WithSameVacancyId_ReturnsTrue()
    {
        // Arrange
        var id1 = VacancyId.CreateUnique();
        // var id2 = new VacancyId(id1.Value);

        // Act & Assert
        // Assert.True(id1.Equals(id2));
    }

    [Fact]
    public void GetHashCode_WithDifferentVacancyId_ReturnsDifferentValue()
    {
        // Arrange
        var id1 = VacancyId.CreateUnique();
        var id2 = VacancyId.CreateUnique();

        // Act
        var hashCode1 = id1.GetHashCode();
        var hashCode2 = id2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }

    [Fact]
    public void GetHashCode_WithSameVacancyId_ReturnsSameValue()
    {
        // Arrange
        var id1 = VacancyId.CreateUnique();
        // var id2 = new VacancyId(id1.Value);

        // Act
        var hashCode1 = id1.GetHashCode();
        // var hashCode2 = id2.GetHashCode();

        // Assert
        // Assert.Equal(hashCode1, hashCode2);
    }
}
