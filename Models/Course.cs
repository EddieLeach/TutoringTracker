namespace TutoringTracker.Models;

public class Course
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;  // e.g. "MATH-1314"
    public string Title { get; set; } = default!;
}
