# blazing-resume
A simple blazor-wasm resumé creator.
Have you ever had to update your resumé only to find out that your design has been messed up? Or tried to create a resume using a
free online editor, only to find out that it was in fact paid for downloading?
This project is conceived to be a truly free resumé creation tool with minimal hosting costs. By using Blazor WASM combined with 
QuestPDF we can create and generate resumés on the client side only. So other than hosting the WebApp, there's no costs involved.
As a giant plus, this tool will not have to send any private info to a backend system, making it much more privacy friendly than
a lot of free alternatives.

## Prerequisites
In order to work on this project you need the following:

### DotNet
Currently the project is build using .NET 8 (8.0.201), so please download and install the proper version from [Microsoft's download page](https://dotnet.microsoft.com/en-us/download)
or alternatively you could use the following command:

	winget install Microsoft.DotNet.SDK.8

### QuestPDF.Preview
We use the QuestPDF library to generate the resumé in PDF format, as you create templates using code its greatly recomended 
to install the QuestPDF.Preview tool in order to make use of hot-reload capabilities. Install it using this command:

	dotnet tool install --global QuestPDF.Previewer

#### DotNet runtime for QuestPDF.Preview
Currently the QuestPDF.Preview tool needs the .NET 6 runtime to start, either download the runtime or the SDK.
	
	dotnet install Microsoft.DotNet.SDK.6

or

	dotnet install Microsoft.DotNet.Runtime.6

### Wasm-tools workload
You'll need the wasm-tools workload in order to build the blazing-resume.web project. You can easily install these with the following 
command:

	dotnet workload install wasm-tools

If, for some reason, you are not able to build and run the project, it might be that your .NET SDK version is newer than the project's target version.
[Please see this section in Microsoft Learn for more info](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows#net-webassembly-build-tools)

## Getting started
After installing the prerequisites its time to restore the projects, run:

	dotnet restore

You should be ready to go now. If you have any suggestions, improvements or questions, please visit the [blazing-resume project on Github](https://github.com/stef-spee/blazing-resume)