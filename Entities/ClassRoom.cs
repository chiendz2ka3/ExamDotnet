using System;
using System.Collections.Generic;

namespace Exam2.Entities;

public partial class ClassRoom
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}
