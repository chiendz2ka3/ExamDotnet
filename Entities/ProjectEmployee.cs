using System;
using System.Collections.Generic;

namespace Exam2.Entities;

public partial class ProjectEmployee
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? Projectid { get; set; }

    public string? Tasks { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Project? Project { get; set; }
}
