namespace Tartaro.ServerApp.Data.Entities;

public partial class User
{
    public long UserId { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime? LastActivicty { get; set; }
}
