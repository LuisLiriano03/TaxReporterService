namespace TaxReporter.Entities;

public partial class Rol
{
    public int RolId { get; set; }

    public string? NameRol { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; } = new List<MenuRol>();

    public virtual ICollection<UserInfo> UserInfos { get; } = new List<UserInfo>();
}
