using ElectronNET.API;
using RTraiding.Application;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// dependencies
services.AddApplication();

var app = builder.Build();

app.Run();

