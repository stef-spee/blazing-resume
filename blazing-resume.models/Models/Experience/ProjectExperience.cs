namespace blazing_resume.models;

public sealed class ProjectExperience
{
    public string Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; }
    public List<string> Highlights { get; set; } = new();
    public string Url { get; set; }
}
