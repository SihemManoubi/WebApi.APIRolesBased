using System;
using System.Collections.Generic;

namespace WebApp.CoreDomain.Entities;

public partial class Department
{
    public int Iddep { get; set; }

    public string Name { get; set; } = null!;

    public string Faculty { get; set; } = null!;
}
