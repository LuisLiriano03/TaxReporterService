namespace TaxReporter.Entities;

public partial class Menu
{
    public int MenuId { get; set; }

    public string? NameMenu { get; set; }

    public string? IconMenu { get; set; }

    public string? UrlMenu { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; } = new List<MenuRol>();
}
