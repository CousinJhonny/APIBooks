using System;
using System.Collections.Generic;

namespace apiBOOKS.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Genre { get; set; }

    public string? Author { get; set; }

    public string? Picture { get; set; }
}
