using EFCoreExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreExample.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Ignore(u => u.Age);
        builder.Property<int?>("AgeRepresentation").HasColumnName("Age");

        //builder.Ignore(u => u.EmploymentType);
        //builder.Property<int?>("EmploymentTypeRepresentation").HasColumnName("EmploymentType");
    }
}
