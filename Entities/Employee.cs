using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exam2.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    [Required, MaxLength(150) , MinLength(2)]
    public string? EmployeeName { get; set; }

    public DateTime? EmployeeDob { get; set; }

    public string? EmployeeDepartment { get; set; }

    public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();
}
