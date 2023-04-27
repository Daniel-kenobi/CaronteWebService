using System;
using System.Collections.Generic;

namespace Tartaro.Data.Entities;

public partial class User
{
    public long UserId { get; set; }

    public string Username { get; set; } = null!;

    public string? WindowsVersion { get; set; }

    public DateTime? LastActivicty { get; set; }
}
