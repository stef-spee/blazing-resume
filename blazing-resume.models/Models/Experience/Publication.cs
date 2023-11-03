namespace blazing_resume.models;

public sealed class Publication
{
    public string Name { get; set; }
    public string Publisher { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Url { get; set; }
    public string Summary { get; set; }
}
