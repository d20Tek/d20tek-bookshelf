namespace D20Tek.Bookshelf.Web.Domain;

internal sealed class Editions
{
    private static readonly DndEdition[] _editions =
    [
        new("Oed", "Original Dungeons & Dragons", "ODnD", 1974, 1977),
        new("1ed", "Advanced Dungeons & Dragons","ADnD", 1977, 1989),
        new("2ed", "Advanced Dungeons & Dragons 2nd Edition","ADnD2E", 1989, 2000),
        new("3ed", "Dungeons & Dragons 3rd Edition","DnD3E", 2000, 2003),
        new("35ed", "Dungeons & Dragons v.3.5","DnD35E", 2003, 2008),
        new("4ed", "Dungeons & Dragons 4th Edition","DnD4E", 2008, 2014),
        new("5ed2024", "Dungeons & Dragons 2024", "DnD2024", 2024, DateTime.Now.Year)
    ];

    public static DndEdition GetEdition(string code) => _editions.First(x => x.Code == code);
}
