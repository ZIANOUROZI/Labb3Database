using System;
using System.Collections.Generic;

namespace Labb3Database.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int GradeBetyg { get; set; }

    public DateTime DateTime { get; set; }

    public int? FkstudentId { get; set; }

    public int? FkcourseId { get; set; }

    public virtual Courss? Fkcourse { get; set; }

    public virtual Student? Fkstudent { get; set; }
}
