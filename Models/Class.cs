using System;
using System.Collections.Generic;

namespace Labb3Database.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public virtual ICollection<Courss> Coursses { get; set; } = new List<Courss>();
}
