using System;
using System.Collections.Generic;

namespace Labb3Database.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string Name { get; set; } = null!;

    public int FkroleId { get; set; }

    public virtual ICollection<Courss> Coursses { get; set; } = new List<Courss>();

    public virtual Role Fkrole { get; set; } = null!;
}
