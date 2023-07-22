using System;
using System.Collections.Generic;

namespace Exam2.Entities;

public partial class Project
{
    public int Projectid { get; set; }

    public string? ProjectName { get; set; }

    public DateTime? ProjectStartDate { get; set; }

    public DateTime? ProjectEndDate { get; set; }

    public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();
}
