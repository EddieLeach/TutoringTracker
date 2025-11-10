namespace TutoringTracker.Models;

public class Visit
{
    public int Id { get; set; }

    // Proper FK to Students table
    public int StudentId { get; set; }
    public Student Student { get; set; } = default!;

    // Proper FK to Courses table
    public int CourseId { get; set; }
    public Course Course { get; set; } = default!;

    public string Reason { get; set; } = default!;
    public DateTime CheckInTime { get; set; }
}
