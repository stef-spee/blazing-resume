namespace blazing_resume.models;

public sealed class Skill
{
    public string Name { get; set; }
    public string Level { get; set; }
    public List<string> Keywords { get; set; } = new();
}
