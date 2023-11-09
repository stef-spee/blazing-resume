namespace blazing_resume.models;

public sealed class Basics
{
    public string Name { get; set; }
    public string Label { get; set; }
    public byte[] Image { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Url { get; set; }
    public string Summary { get; set; }
    public Location Location { get; set; } = new();
    public List<Profile> Profiles { get; set; } = new();
}
