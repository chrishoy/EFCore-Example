using LanguageExt;

namespace EFCoreExample.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public Option<int> Age { get; set; } = Option<int>.None;

    private int? AgeRepresentation
    {
        get => Age.ToNullable();
        set => Age = Prelude.toOption(value);
    }

    //public EmploymentType EmploymentType { get; set; } = new FullTime();

    //private EmploymentTypeRepresentation EmploymentTypeRepresentation
    //{
    //    get => EmploymentType.ToRepresentation();
    //    set => EmploymentType = value.ToEmploymentType();
    //}
}
