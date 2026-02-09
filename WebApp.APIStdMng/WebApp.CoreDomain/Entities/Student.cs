using System;
using System.Collections.Generic;

namespace WebApp.CoreDomain.Entities;

/// <summary>
/// Table contient la liste des étudiants
/// </summary>
public partial class Student
{
    public string Matricule { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime Registerdate { get; set; }

    public string Faculty { get; set; } = null!;

    public string? Average { get; set; }

    public string Section { get; set; } = null!;

    public string? Status { get; set; }
}
