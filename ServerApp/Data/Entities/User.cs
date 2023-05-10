using System;
using System.Collections.Generic;

namespace Tartaro.ServerApp.Data.Entities;

public partial class User
{
    public long UserId { get; set; }

    public string Username { get; set; } = null!;

    public DateTime? LastActivicty { get; set; }
}
