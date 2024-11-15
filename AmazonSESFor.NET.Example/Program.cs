using Amazon.SimpleEmail;
using AmazonSESFor.NET.Example.Models;
using AmazonSESFor.NET.Example.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonSimpleEmailService>();
builder.Services.AddSingleton<IMailService, AmazonSESService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapPost("/send-mail", async (MailRequestModel mailRequest, IMailService sesService)
    => await sesService.SendEmailAsync(mailRequest));

app.Run();
