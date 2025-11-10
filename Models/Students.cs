namespace TutoringTracker.Models;

public class Student
{
    public int Id { get; set; }
    public string StudentId { get; set; } = default!; // e.g. "S12345"
    public string Name { get; set; } = default!;
}
