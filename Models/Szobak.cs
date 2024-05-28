using System;
using System.Collections.Generic;

namespace fogado.Models;

public partial class Szobak
{
    public int Szazon { get; set; }

    public string Sznev { get; set; } = null!;

    public int Agy { get; set; }

    public int Potagy { get; set; }

    public virtual ICollection<Foglalasok> Foglalasoks { get; set; } = new List<Foglalasok>();
}
