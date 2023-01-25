using ShaleFoods.Domain.Common.Models;

namespace ShaleFoods.Domain.Vacancy.ValueObjects;

public sealed class SalaryFork : ValueObject
{
    public int MinSalary;
    public int MaxSalary;

    private SalaryFork(int minSalary, int maxSalary)
    {
        if (minSalary < 0 || maxSalary < 0)
        {
            throw new ArgumentException("Salary should not be negative");
        }

        if (minSalary > maxSalary)
        {
            throw new ArgumentException("Max salary should be greater than min salary");
        }
        MinSalary = minSalary;
        MaxSalary = maxSalary;
    }

    public static SalaryFork CreateUnique(int minSalary, int maxSalary)
    {
        return new SalaryFork(minSalary, maxSalary);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return MinSalary;
        yield return MaxSalary;
    }
}