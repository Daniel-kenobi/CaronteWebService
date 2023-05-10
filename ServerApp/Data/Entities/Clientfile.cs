using System;
using System.Collections.Generic;

namespace Tartaro.ServerApp.Data.Entities;

public partial class Clientfile
{
    public long ClientFileId { get; set; }

    public string FilePath { get; set; } = null!;

    public long ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
