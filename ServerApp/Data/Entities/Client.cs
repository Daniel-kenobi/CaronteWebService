using System;
using System.Collections.Generic;

namespace Tartaro.ServerApp.Data.Entities;

public partial class Client
{
    public long ClientId { get; set; }

    public string ClientName { get; set; } = null!;

    public string? LocalIp { get; set; }

    public string? ExternalIp { get; set; }

    public string ProcessorIdentifier { get; set; } = null!;

    public string? Osversion { get; set; }

    public DateTime? LastActivicty { get; set; }

    public virtual ICollection<Clientfile> Clientfiles { get; set; } = new List<Clientfile>();
}
