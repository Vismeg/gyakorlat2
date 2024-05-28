using System;
using System.Collections.Generic;

namespace fogado.Models;

public partial class Vendegek
{
    public int Vsorsz { get; set; }

    public string Vnev { get; set; } = null!;

    public int Irsz { get; set; }

    public virtual ICollection<Foglalasok> Foglalasoks { get; set; } = new List<Foglalasok>();
}
