using blazing_resume.models;
using Bogus;
using System;
using System.Net;

namespace blazing_resume.mock;

public static class MockData
{
    public static ResumeModel GetMockResumeInfo() =>
        new Faker<ResumeModel>()
            .CustomInstantiator(_ => new ResumeModel())
            .RuleFor(o => o.Basics, _ => GetUserInfo())
            .RuleFor(o => o.Work, _ => GetWorkExperience());

    private static Basics GetUserInfo()
    {
        return new Faker<Basics>()
                .CustomInstantiator(_ => new Basics())
                .RuleFor(o => o.Name, f => f.Person.FullName)
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.Location, _ => GetLocation())
                .RuleFor(o => o.Profiles, _ => GetProfiles())
                .RuleFor(o => o.Phone, f => f.Person.Phone)
                .RuleFor(o => o.Url, f => f.Person.Website)
                .RuleFor(o => o.Summary, "I like coffee and cookies.")
                .RuleFor(o => o.Image, f => f.Image.LoremFlickrUrl())
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
                .GenerateBetween(2, 4);
}