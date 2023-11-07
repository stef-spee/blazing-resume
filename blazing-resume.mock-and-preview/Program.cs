using blazing_resume.mock;
using blazing_resume.pdf;
using QuestPDF.Fluent;
using QuestPDF.Previewer;

QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
// code in your main method
var document = new PdfGenerator(MockData.GetMockResumeInfo()).SetupPdfDocument();
// instead of the standard way of generating a PDF file
document.GeneratePdf("hello.pdf");
// use the following invocation
document.ShowInPreviewer();
// optionally, you can specify an HTTP port to communicate with the previewer host (default is 12500)
document.ShowInPreviewer(12345);