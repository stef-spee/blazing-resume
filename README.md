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
Currently the project is build using .NET 7, so install the proper version [using this link](https://dotnet.microsoft.com/en-us/download)
or alternatively you could use the following command:

	winget install Microsoft.DotNet.SDK.7

### QuestPDF.Preview
We use the QuestPDF library to generate the resumé in PDF format, as you create templates using code its greatly recomended 
to install the QuestPDF.Preview tool in order to make use of hot-reload capabilities. Install it using this command:

	dotnet tool install --global QuestPDF.Previewer

### Wasm-tools workload
You'll need the wasm-tools workload in order to build the blazing-resume.web project. You can easily install these with the following 
command: (for .net 7 projects you need the net6 tools)

	dotnet workload install wasm-tools-net6

## Getting started
After installing the prerequisites its time to restore the projects, run:

	dotnet restore

Now you should be ready to go. If you have any suggestions, improvements or questions, please visit the [project on Github](https://github.com/stef-spee/blazing-resume)