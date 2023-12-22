using System;
using System.Collections.Generic;

namespace Labb3Database.Models;

public partial class Courss
{
    public int CourssId { get; set; }

    public string CourssName { get; set; } = null!;

    public int? FkstaffId { get; set; }

    public int? FkclassId { get; set; }

    public virtual Class? Fkclass { get; set; }

    public virtual Staff? Fkstaff { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
