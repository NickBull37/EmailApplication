# Email Applicaton #

This is a simple email application implemeted using a ASP.NET Web Api that takes an email address, subject, and message body and sends the email using Gmail's SMTP server.

## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [Libraries Used](#libraries-used)
* [Features](#features)
* [Setup](#setup)
* [Execution](#execution)
* [Testing with Swagger](#testing-with-swagger)
* [Testing with Postman](#testing-with-postman)


## General Information
- Sends emails using Gmail's SMTP Server
- Email settings and credentials are stored in appsettings.Development.json
- Sender email (nbuliskysmtptest@gmail.com) is a test gmail account set up with an application password for this program

## Technologies Used
- .NET Core 3.1

## Libraries Used
- MailKit 3.4.2
- MimeKit 3.4.2
- Serilog 2.12.0
- Serilog.Enrichers.Environment 2.2.0
- Serilog.Exceptions 8.4.0
- Serilog.Settings.Configuration 3.4.0
- Serilog.Sinks.Console 4.1.0
- Serilog.Sinks.File 5.0.0
- Serilog.Sinks.RollingFile 3.3.0
- Swashbuckle.AspNetCore.Swagger 6.4.0
- Swashbuckle.AspNetCore.SwaggerGen 6.4.0
- Swashbuckle.AspNetCore.SwaggerUI 6.4.0
- System.Configuration.ConfigurationManager 7.0.0

## Features
Features include:
- Console and text file logging
- Automatic retry on failure (max 3 tries)

## Setup
- Create directory at C:\Logs\API.Serilog\ (file will auto-generate the first time the program is executed)

## Execution
- Execute program in Visual Studio to use Swagger UI for testing
- Execute program with command [dotnet run] from \EmailApplication directory to use Postman for testing

## Testing with Swagger
1) Execute the program
2) Click on the green /SendEmail endpoint and then the [Try it out] button in the top right corner
3) Enter recipient email address, email subject, and email body in the text boxes below
4) Click the blue [Execute] button to send post request
5) The email status will be displayed in the Server response section
* The values of the {ToEmail}, {Subject}, and {Body} query parameters can all be modified for different tests
* Screenshots are included with details for a successful test case and a failed test case

## Testing with Postman
1) Execute the program
2) Create new API Post request
3) Enter API request url
4) Enter query param keys for {ToEmail}, {Subject}, and {Body}
5) Enter query param keys values for {ToEmail}, {Subject}, and {Body}
6) Click the blue [Send] button to send post request
* The values of the {ToEmail}, {Subject}, and {Body} query parameters can all be modified for different tests
* Screenshots are included with details for a successful test case and a failed test case
