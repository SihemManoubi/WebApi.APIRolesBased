using System;
using System.Collections.Generic;

namespace WebApp.CoreDomain.Entities;

/// <summary>
/// Table contient la liste des utilisateurs
/// </summary>
public partial class User
{
    public int Idusr { get; set; }

    public string Matricule { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Token { get; set; }

    public string? Role { get; set; }

    public string? Refreshtoken { get; set; }

    public DateTime? Refreshtokenexpirytime { get; set; }

    public string? Accesstoken { get; set; }
}
