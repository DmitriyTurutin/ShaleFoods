using ShaleFoods.Domain.Common.Models;
using ShaleFoods.Domain.Vacancy.ValueObjects;

namespace ShaleFoods.Domain.Vacancy;

public sealed class Vacancy : AggregateRoot<VacancyId>
{
    public string Title { get; }
    public int Experience { get; }
    public SalaryFork Salary { get; }
    public string Description { get; }
    public readonly List<string> _requiredSkills = new();
    public readonly List<string> _goodToKnow = new();
    public string WorkingConditions { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private Vacancy(
        VacancyId id,
        string title,
        int experience,
        SalaryFork salaryFork,
        string description,
        List<string> requiredSkills,
        List<string> goodToKnow,
        string workingConditions,
        DateTime createdAt,
        DateTime updatedAt)
        : base(id)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title should not be empty!");
        }

        if (experience < 0)
        {
            throw new ArgumentException("Experience should not be negative!");
        }
        
        Title = title;
        Experience = experience;
        Salary = salaryFork;
        Description = description;
        _requiredSkills = requiredSkills;
        _goodToKnow = goodToKnow;
        WorkingConditions = workingConditions;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Vacancy Create(
        string title,
        int experience,
        SalaryFork salaryFork,
        string description,
        List<string> requiredSkills,
        List<string> goodTodKnow,
        string workingConditions)
    {
        return new(
            VacancyId.CreateUnique(),
            title,
            experience,
            salaryFork,
            description,
            requiredSkills,
            goodTodKnow,
            workingConditions,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}