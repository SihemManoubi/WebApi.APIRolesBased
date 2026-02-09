using System;
using System.Collections.Generic;

namespace WebApp.CoreDomain.Entities;

/// <summary>
/// Table des matières
/// </summary>
public partial class Matiere
{
    public int Idmat { get; set; }

    public string? Designation { get; set; }
}
