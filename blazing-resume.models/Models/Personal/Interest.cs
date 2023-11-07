namespace blazing_resume.models;

public sealed class Interest
{
    public string Name { get; set; }
    public List<string> Keywords { get; set; } = new();
}
