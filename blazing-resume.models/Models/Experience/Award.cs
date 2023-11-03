namespace blazing_resume.models;

public sealed class Award
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Awarder { get; set; }
    public string Summary { get; set; }
}
