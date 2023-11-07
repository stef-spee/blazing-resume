namespace blazing_resume.models;

public sealed class Education
{
    public string Institution { get; set; }
    public string Url { get; set; }
    public string Area { get; set; }
    public string StudyType { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Score { get; set; }
    public List<string> Courses { get; set; } = new();
}
