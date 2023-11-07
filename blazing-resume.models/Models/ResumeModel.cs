namespace blazing_resume.models;

public sealed class ResumeModel
{
    public Basics Basics { get; set; } = new();
    public List<WorkExperience> Work { get; set; } = new();
    public List<VolunteerExperience> Volunteer { get; set; } = new();
    public List<Education> Education { get; set; } = new();
    public List<Award> Award { get; set; } = new();
    public List<Certificate> Certificates { get; set; } = new();
    public List<Publication> Publications { get; set; } = new();
    public List<Skill> Skills { get; set; } = new();
    public List<LanguageProficiency> Languages { get; set; } = new();
    public List<Interest> Interests { get; set; } = new();
    public List<ReferenceContact> References { get; set; } = new();
    public List<ProjectExperience> Projects { get; set; } = new();
}
