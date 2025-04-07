namespace D20Tek.Bookshelf.Web.Domain;

public sealed class DndEdition
{
    public string Code { get; }

    public string Name { get; }

    public string Abbr { get; }

    public int StartYear { get; }

    public int EndYear { get; }

    public DndEdition(string code, string name, string abbr, int startYear, int endYear)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(code, nameof(code));
        ArgumentNullException.ThrowIfNull(name, nameof(name));
        ArgumentNullException.ThrowIfNullOrEmpty(abbr, nameof(abbr));
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(startYear, 0, nameof(startYear));
        ArgumentOutOfRangeException.ThrowIfLessThan(endYear, startYear, nameof(endYear));

        Code = code;
        Name = name;
        Abbr = abbr;
        StartYear = startYear;
        EndYear = endYear;
    }
}
