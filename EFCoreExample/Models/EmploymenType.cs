namespace EFCoreExample.Models;

/// <summary>
/// Discriminated union of employment types
/// </summary>
public abstract record EmploymentType;
public sealed record FullTime : EmploymentType;
public sealed record PartTime : EmploymentType;
public sealed record Contractor : EmploymentType;

public sealed record EmploymentTypeRepresentation(Type Discriminator, string FriendlyName);

public static class EmploymentTypeConversions
{
    public static EmploymentTypeRepresentation ToRepresentation(this EmploymentType employmentType) =>
        employmentType switch
        {
            FullTime => new EmploymentTypeRepresentation(typeof(FullTime), "Full Time"),
            PartTime => new EmploymentTypeRepresentation(typeof(PartTime), "Part Time"),
            Contractor => new EmploymentTypeRepresentation(typeof(Contractor), "Contractor"),
            _ => throw new ArgumentException("Unknown employment type")
        };

    public static EmploymentType ToEmploymentType(this EmploymentTypeRepresentation employmentTypeRepresentation) =>
        employmentTypeRepresentation.Discriminator switch
        {
            Type t when t == typeof(FullTime) => new FullTime(),
            Type t when t == typeof(PartTime) => new PartTime(),
            Type t when t == typeof(Contractor) => new Contractor(),
            _ => throw new ArgumentException("Unknown employment type")
        };
    // Can also use Activator.CreateInstance(employmentTypeRepresentation.Discriminator) as EmploymentType, which also accepts constructor parameters
}
