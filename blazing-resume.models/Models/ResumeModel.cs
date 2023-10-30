namespace blazing_resume.models;

public sealed class ResumeModel
{
    public Basics Basics { get; set; }
    public List<WorkExperience> Work { get; set; }
    public List<VolunteerExperience> Volunteer { get; set; }
    public List<Education> Education { get; set; }
    public List<Award> Award { get; set; }
    public List<Certificate> Certificates { get; set; }
    public List<Publication> Publications { get; set; }
    public List<Skill> Skills { get; set; }
    public List<LanguageProficiency> Languages { get; set; }
    public List<Interest> Interests { get; set; }
    public List<ReferenceContact> References { get; set; }
    public List<ProjectExperience> Projects { get; set; }
}
