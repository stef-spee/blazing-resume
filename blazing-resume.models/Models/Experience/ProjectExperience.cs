namespace blazing_resume.models;

public sealed class ProjectExperience
{
    public string Name { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Description { get; set; }
    public List<string> Highlights { get; set; }
    public string Url { get; set; }
}
