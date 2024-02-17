using blazing_resume.models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace blazing_resume.pdf.Basic;

public sealed class Modern_Clean : IDocument
{
    private readonly ResumeModel _model;

    public Modern_Clean(ResumeModel model)
    {
        _model = model;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    public DocumentSettings GetSettings() => DocumentSettings.Default;

    public void Compose(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.DefaultTextStyle(x => x.FontFamily("Gill Sans MT")
                                                   .FontSize(11)
                                                   .FontColor(Colors.Grey.Darken4)
                                                   .Weight(FontWeight.Medium)
                                    );
                page.Content()
                    .Background(Colors.Grey.Lighten3)
                    .Row(row =>
                    {
                        row.ConstantItem(200)
                           .Background(Colors.Grey.Darken4)
                           .ExtendVertical()
                           .Element(ComposeSideBar);

                        row.RelativeItem()
                           .ExtendVertical()
                           .Column(col => {
                               col.Item()
                                  .Element(ComposeEducationAndCertificates);
                               col.Item()
                                  .Element(ComposeWorkExperiences);
                            });
                    });
            });
    }

    void ComposeSideBar(IContainer container)
    {
        container.DefaultTextStyle(x =>
             x.FontColor(Colors.Grey.Lighten2)
        )
        .PaddingHorizontal(15)
        .Column(sidebar =>
        {
        sidebar.Spacing(30);

        if (_model.Basics.Image != null && _model.Basics.Image.Length > 0)
        {
            sidebar.Item()
               .PaddingTop(30)
               .AlignCenter()
               .MaxHeight(150)
               .Image(_model.Basics.Image);
        }
        else
        {
            sidebar.Item().PaddingTop(20);
        }

        sidebar.Item()
           .AlignCenter()
           .Column(column =>
           {
               column.Item()
                     .AlignCenter()
                     .Text(_model.Basics.Name)
                     .FontSize(16)
                     .Black();
               column.Item()
                     .AlignCenter()
                     .Text(_model.Basics.Label)
                     .Italic()
                     .FontSize(10);
           });

        sidebar.Item()
            .Text(_model.Basics.Summary);

        sidebar.Item()
            .AlignLeft()
            .Column(column =>
            {
                column.Item()
                      .Text("Contacts")
                      .Underline()
                      .FontSize(16)
                      .Bold();

                column.Item().Column(contacts =>
                {
                    contacts.Item()
                            .PaddingTop(5)
                            .Text("Location")
                            .Light()
                            .FontSize(9);
                    contacts.Item()
                            .Text($"{_model.Basics.Location.Address}, {_model.Basics.Location.City}")
                            .Italic();

                    contacts.Item()
                            .PaddingTop(5)
                            .Text("Phone")
                            .Light()
                            .FontSize(9);
                    contacts.Item()
                            .Text(_model.Basics.Phone)
                            .Italic();

                    contacts.Item()
                            .PaddingTop(5)
                            .Text("E-mail")
                            .Light()
                            .FontSize(9);
                    contacts.Item()
                            .Text(_model.Basics.Email)
                            .Italic();

                    //contacts.Item()
                    //        .PaddingTop(5)
                    //        .Text("LinkedIn")
                    //        .Light()
                    //        .FontSize(9);
                });
            });

        sidebar.Item()
                .AlignLeft()
                .Column(column =>
                {
                    column.Item()
                        .PaddingBottom(5)
                        .Text("Skills")
                        .Underline()
                        .FontSize(16)
                        .Bold();

                    column.Item().Column(skills =>
                    {
                        foreach (var skill in _model.Skills)
                        {
                            skills.Item().Text(skill.Name);
                        }
                    });
                });

        sidebar.Item()
                .AlignLeft()
                .Column(column =>
                {
                    column.Item()
                          .PaddingBottom(5)
                          .Text("Interests")
                          .Underline()
                          .FontSize(16)
                          .Bold();

                    column.Item().Column(interests =>
                    {
                        foreach (var interest in _model.Interests)
                        {
                            interests.Item().Text(interest.Name);
                        }
                    });
                });
        });
    }

    void ComposeEducationAndCertificates(IContainer container)
    {
        container.PaddingTop(50)
        .PaddingHorizontal(35)
        .AlignMiddle()
        .Column(column =>
        {
            column.Spacing(10);
            column.Item().Column(col =>
            {
                col.Spacing(3);

                col.Item().Text("Education").FontSize(16).ExtraBold();
                col.Item()
                   .TranslateY(-5)
                   .LineHorizontal(1);
                foreach (var education in _model.Education.OrderByDescending(x => x.StartDate).ThenBy(x => x.EndDate).Take(5))
                {
                    col.Item().Column(educationElement =>
                    {
                        educationElement.Item().Text($"[{education.StudyType}] {education.Area}").Bold();
                        educationElement.Item().Text($"{education.Institution} | {education.StartDate?.Year} - {education.EndDate?.Year}");
                    });
                }
            });

            column.Item().Column(col =>
            {
                col.Spacing(3);

                col.Item().Text("Certificates").FontSize(16).ExtraBold();
                col.Item()
                   .TranslateY(-5)
                   .LineHorizontal(1);
                foreach (var certificate in _model.Certificates.OrderByDescending(x => x.Date).Take(5))
                {
                    col.Item().Column(certElement =>
                    {
                        certElement.Item().Text(certificate.Name).Bold();
                        certElement.Item().Text($"{certificate.Issuer} | {certificate.Date?.ToString("MM/yyyy")}");
                    });
                }
            });
        });
    }

    void ComposeWorkExperiences(IContainer container)
    {
        container.PaddingTop(50)
        .PaddingHorizontal(35)
        .Column(column =>
        {
            column.Spacing(15);

            column.Item().Text("Work experience").FontSize(16).ExtraBold();
            column.Item()
                  .TranslateY(-5)
                  .LineHorizontal(1);
            foreach (var work in _model.Work.OrderByDescending(x => x.StartDate)
                                            .ThenBy(x => x.EndDate)
                                            .Take(5))
            {
                column.Item().Column(workElement =>
                {
                    workElement.Item()
                               .PaddingBottom(5)
                               .Text(work.Position)
                               .FontSize(12)
                               .SemiBold();
                    workElement.Item()
                               .Text($"{work.Name}, {work.StartDate?.Year} - {work.EndDate?.Year}")
                               .FontSize(10)
                               .Medium()
                               .Italic();
                    workElement.Item()
                               .Text(work.Summary);
                });
            }
        });
    }
}