using ShaleFoods.Domain.Common.Models;

namespace ShaleFoods.Domain.Vacancy.ValueObjects;

public sealed class VacancyId : ValueObject
{
    private Guid Value { get; }

    private VacancyId(Guid value)
    {
        Value = value;
    }

    public static VacancyId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}