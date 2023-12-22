using System;
using System.Collections.Generic;

namespace Labb3Database.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string PersonNumber { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
