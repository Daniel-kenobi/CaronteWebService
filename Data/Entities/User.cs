namespace Tartaro.Data.Entities;

public partial class User
{
    public long UserId { get; set; }

    public string Username { get; set; } = null!;

    public string? OSVersion { get; set; }

    public DateTime? LastActivicty { get; set; }
}
