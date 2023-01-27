using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShaleFoods.Domain.Vacancy;

namespace ShaleFoods.Infrastructure.Persistence.Configurations;

public class VacancyConfigurations : IEntityTypeConfiguration<Vacancy>
{
    public void Configure(EntityTypeBuilder<Vacancy> builder)
    {
        ConfigureVacanciesTable(builder);
    }

    private void ConfigureVacanciesTable(EntityTypeBuilder<Vacancy> builder)
    {
        builder.ToTable("Vacancy");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();
        builder.Property(x => x.Title)
            .HasColumnName("Title")
            .IsRequired();
        builder.Property(x => x.Experience)
            .HasColumnName("Experience")
            .IsRequired();
        // builder.Property(x => x.MinSalary).HasColumnName("MinSalary").IsRequired();
        // builder.Property(x => x.MaxSalary).HasColumnName("MaxSalary").IsRequired();
        builder.Property(x => x.Description)
            .HasColumnName("Description")
            .IsRequired();
        // builder.Property(x => x.RequiredSkills).HasColumnName("RequiredSkills").IsRequired();
        // builder.Property(x => x.GoodToKnow).HasColumnName("GoodToKnow").IsRequired();
        builder.Property(x => x.WorkingConditions)
            .HasColumnName("WorkingConditions")
            .IsRequired();
    }
}