using blazing_resume.models;
using Bogus;
using System.Net;

namespace blazing_resume.mock;

public static class MockData
{
    public static ResumeModel GetMockResumeInfo() =>
        new Faker<ResumeModel>()
            .CustomInstantiator(_ => new ResumeModel())
            .RuleFor(o => o.Basics, _ => GetUserInfo())
            .RuleFor(o => o.Work, _ => GetWorkExperience())
            .RuleFor(o => o.Volunteer, _ => GetVolunteerExperiences())
            .RuleFor(o => o.Education, _ => GetEducations())
            .RuleFor(o => o.Award, _ => GetAwards())
            .RuleFor(o => o.Certificates, _ => GetCertificates())
            .RuleFor(o => o.Publications, GetPublications())
            .RuleFor(o => o.Skills, GetSkills())
            .RuleFor(o => o.Languages, GetLanguageProficiencies())
            .RuleFor(o => o.Interests, GetInterests())
            .RuleFor(o => o.References, GetReferences())
            .RuleFor(o => o.Projects, GetProjects());

    private static Basics GetUserInfo()
    {
        return new Faker<Basics>()
                .CustomInstantiator(_ => new Basics())
                .RuleFor(o => o.Name, f => f.Person.FullName)
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.Label, "Professional data model")
                .RuleFor(o => o.Location, _ => GetLocation())
                .RuleFor(o => o.Profiles, _ => GetProfiles())
                .RuleFor(o => o.Phone, f => f.Person.Phone)
                .RuleFor(o => o.Url, f => f.Person.Website)
                .RuleFor(o => o.Summary, f => f.Lorem.Paragraph())
                .RuleFor(o => o.Image, f => {
                    byte[] img;
                    using (HttpClient webClient = new())
                    {
                        img = webClient.GetByteArrayAsync(f.Image.LoremFlickrUrl()).Result;
                    }
                    return img;
                })
                .Generate();
    }

    private static Location GetLocation() =>
            new Faker<Location>()
                .CustomInstantiator(_ => new Location())
                .RuleFor(o => o.City, f => f.Address.City())
                .RuleFor(o => o.Address, f => f.Address.StreetAddress())
                .RuleFor(o => o.PostalCode, f => f.Address.ZipCode())
                .RuleFor(o => o.CountryCode, f => f.Address.CountryCode())
                .RuleFor(o => o.Region, f => f.Address.State())
                .Generate();

    private static List<Profile> GetProfiles() =>
            new Faker<Profile>()
                .RuleFor(o => o.Network, f => f.Internet.DomainName())
                .RuleFor(o => o.Username, f => f.Internet.UserName())
                .RuleFor(o => o.Url, f => f.Internet.Url())
                .GenerateBetween(1, 2);

    private static List<WorkExperience> GetWorkExperience() =>
            new Faker<WorkExperience>()
                .CustomInstantiator(_ => new WorkExperience())
                .RuleFor(o => o.Name, f => f.Company.CompanyName())
                .RuleFor(o => o.Position, f => f.Commerce.Department())
                .RuleFor(o => o.Url, f => f.Internet.Url())
                .RuleFor(o => o.StartDate, f => f.Date.Past())
                .RuleFor(o => o.EndDate, f => f.Date.Past())
                .RuleFor(o => o.Summary, f => f.Lorem.Paragraph())
                .RuleFor(o => o.Highlights, f => new List<string>() { f.Lorem.Sentence() })
                .GenerateBetween(4, 9);

    private static List<VolunteerExperience> GetVolunteerExperiences() =>
            new Faker<VolunteerExperience>()
                .CustomInstantiator(_ => new VolunteerExperience())
                .RuleFor(o => o.Organization, f => f.Company.CompanyName())
                .RuleFor(o => o.Position, f => f.Lorem.Word())
                .RuleFor(o => o.Url, f => f.Internet.Url())
                .RuleFor(o => o.StartDate, f => f.Date.Past())
                .RuleFor(o => o.EndDate, f => f.Date.Past())
                .RuleFor(o => o.Summary, f => f.Lorem.Paragraph())
                .RuleFor(o => o.Highlights, f => new List<string>() { f.Lorem.Sentence() })
                .GenerateBetween(1, 2);

    private static List<Education> GetEducations() =>
            new Faker<Education>()
            .CustomInstantiator(_ => new Education())
            .RuleFor(o => o.Institution, f => f.Company.CompanyName())
            .RuleFor(o => o.Url, f => f.Internet.Url())
            .RuleFor(o => o.Area, f => string.Concat(f.Lorem.Words(2)))
            .RuleFor(o => o.StudyType, f => f.Lorem.Word())
            .RuleFor(o => o.StartDate, f => f.Date.Past())
            .RuleFor(o => o.EndDate, f => f.Date.Past())
            .RuleFor(o => o.Score, f => f.Random.Decimal(6.0m, 10.0m).ToString())
            .RuleFor(o => o.Courses, f => new List<string> { f.Lorem.Sentence() })
            .GenerateBetween(1, 2);

    private static List<Award> GetAwards() =>
            new Faker<Award>()
            .CustomInstantiator(_ => new Award())
            .RuleFor(o => o.Title, f => f.Lorem.Word())
            .RuleFor(o => o.Date, f => f.Date.Past())
            .RuleFor(o => o.Awarder, f => f.Company.CompanyName())
            .RuleFor(o => o.Summary, f => f.Lorem.Paragraph())
            .GenerateBetween(1, 2);

    private static List<Certificate> GetCertificates() =>
            new Faker<Certificate>()
            .CustomInstantiator(_ => new Certificate())
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .RuleFor(o => o.Date, f => f.Date.Past())
            .RuleFor(o => o.Issuer, f => f.Company.CompanyName())
            .RuleFor(o => o.Url, f => f.Internet.Url())
            .GenerateBetween(1, 2);

    private static List<Publication> GetPublications() =>
            new Faker<Publication>()
            .CustomInstantiator(_ => new Publication())
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .RuleFor(o => o.ReleaseDate, f => f.Date.Past())
            .RuleFor(o => o.Publisher, f => f.Company.CompanyName())
            .RuleFor(o => o.Url, f => f.Internet.Url())
            .RuleFor(o => o.Summary, f => f.Lorem.Sentence())
            .GenerateBetween(1, 2);

    private static List<Skill> GetSkills() =>
            new Faker<Skill>()
            .CustomInstantiator(_ => new Skill())
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .RuleFor(o => o.Level, f => f.Lorem.Word())
            .RuleFor(o => o.Keywords, f => f.Lorem.Words(5).ToList())
            .GenerateBetween(1, 2);

    private static List<LanguageProficiency> GetLanguageProficiencies() =>
            new Faker<LanguageProficiency>()
            .CustomInstantiator(_ => new LanguageProficiency())
            .RuleFor(o => o.Language, f => f.PickRandom("English", "Dutch", "German", "Spanish", "French"))
            .RuleFor(o => o.Fluency, f => f.PickRandom("Native", "Proficient", "Good", "Basic"))
            .GenerateBetween(1, 2);

    private static List<Interest> GetInterests() =>
            new Faker<Interest>()
            .CustomInstantiator(_ => new Interest())
            .RuleFor(o => o.Name, f => f.PickRandom("Wildlife", "Cars", "Gaming", "Software", "Photography", "Baking", "Cooking", "Arts and Crafts"))
            .RuleFor(o => o.Keywords, f => f.Lorem.Words(5).ToList())
            .GenerateBetween(1, 2);

    private static List<ReferenceContact> GetReferences() =>
            new Faker<ReferenceContact>()
            .CustomInstantiator(_ => new ReferenceContact())
            .RuleFor(o => o.Name, f => f.Person.FullName)
            .RuleFor(o => o.Reference, _ => "Reference...")
            .GenerateBetween(1, 2);

    private static List<ProjectExperience> GetProjects() =>
            new Faker<ProjectExperience>()
            .CustomInstantiator(_ => new ProjectExperience())
            .RuleFor(o => o.Name, f => f.Lorem.Word())
            .RuleFor(o => o.Url, f => f.Internet.Url())
            .RuleFor(o => o.StartDate, f => f.Date.Past())
            .RuleFor(o => o.EndDate, f => f.Date.Past())
            .RuleFor(o => o.Description, f => f.Lorem.Paragraph())
            .RuleFor(o => o.Highlights, f => new List<string> { f.Lorem.Sentence() })
            .GenerateBetween(1, 2);
}