using System;
using System.Collections.Generic;

namespace WebApp.CoreDomain.Entities;

public partial class Faculty
{
    public int Idfac { get; set; }

    public int? Iddep { get; set; }

    public string? Matricule { get; set; }

    public string Name { get; set; } = null!;

    public string? Department { get; set; }

    public string? Address { get; set; }
}
