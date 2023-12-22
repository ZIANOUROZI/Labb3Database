using System;
using System.Collections.Generic;

namespace Labb3Database.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Role1 { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
