using blazing_resume.mock;
using blazing_resume.pdf.Basic;
using QuestPDF.Fluent;
using QuestPDF.Previewer;

QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
// code in your main method
var document = new Modern_Clean(MockData.GetMockResumeInfo());
// instead of the standard way of generating a PDF file
document.GeneratePdf("hello.pdf");
// use the following invocation
document.ShowInPreviewer();