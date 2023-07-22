using System;
using System.Collections.Generic;

namespace Exam2.Entities;

public partial class SubjectExam
{
    public int Id { get; set; }

    public string StartTime { get; set; } = null!;

    public DateTime ExamDate { get; set; }

    public string Faculty { get; set; } = null!;

    public string SubJectName { get; set; } = null!;

    public string Classroom { get; set; } = null!;
}
