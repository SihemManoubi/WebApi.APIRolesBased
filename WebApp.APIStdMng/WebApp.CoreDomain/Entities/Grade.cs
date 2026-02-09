using System;
using System.Collections.Generic;

namespace WebApp.CoreDomain.Entities;

public partial class Grade
{
    public int Idnote { get; set; }

    public string? Note { get; set; }

    public string? Matiere { get; set; }
}
