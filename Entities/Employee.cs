using System;
using System.Collections.Generic;

namespace Exam2.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public DateTime? EmployeeDob { get; set; }

    public string? EmployeeDepartment { get; set; }

    public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();
}
