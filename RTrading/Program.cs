using ElectronNET.API;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseElectron(args);
builder.Services.AddElectron();
builder.Services.AddMvc();

var app = builder.Build();

app.Run();

